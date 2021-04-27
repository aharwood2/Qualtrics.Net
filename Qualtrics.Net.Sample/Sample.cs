using Qualtrics.Net.Lang.Requests.SurveyResponseImportExport;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Qualtrics.Net.Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            // Kick off
            var task = Task.Run(async () =>
            {
                // Initialise
                Client.Instance.Initialise(
                    "283105b1-1b28-4741-b876-2d186c79cf64", // Your API token here
                    "https://fra1.qualtrics.com/" // Your base URL here
                    );

                // Run
                var t = new Test();
                await t.Run();
            });

            // Block
            while (!task.IsCompleted)
            {

            };
        }

        class Test
        {
            public async Task Run()
            {
                // Start
                var surveyId = "0b0dd5e3-feca-4e59-a1d5-581a114fda79"; // Your survey ID here
                var res = await Client.Instance.StartResponseExport(surveyId, new ExportCreationRequest
                {
                    Format = "csv"
                });

                // Poll
                var res1 = await Client.Instance.GetResponseExportProgress(res.Result.ProgressId, surveyId);
                while (res1.Result.Status != "complete")
                {
                    await Task.Delay(1000);
                    res1 = await Client.Instance.GetResponseExportProgress(res.Result.ProgressId, surveyId);
                }

                // Get file
                var res2 = await Client.Instance.GetResponseExportFile(res1.Result.FileId, surveyId);

                // Write file from stream
                string tempFilePath = Path.Combine(Path.GetTempPath(), "MyFileName.zip");
                using (var fs = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
                {
                    (res2.FileContents as MemoryStream)?.WriteTo(fs);
                }
            }
        }
    }
}
