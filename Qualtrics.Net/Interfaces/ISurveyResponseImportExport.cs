using Qualtrics.Net.Lang.Requests.SurveyResponseImportExport;
using Qualtrics.Net.Lang.Responses.SurveyResponseImportExport;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Qualtrics.Net.Interfaces
{
    interface ISurveyResponseImportExport
    {
        Task<CreationResponse> StartResponseExport(string surveyId, ExportCreationRequest req);

        Task<ExportStatusResponse> GetResponseExportProgress(string exportProgressId, string surveyId);

        Task<string> GetResponseExportFile(string fileId, string surveyId);
    }
}
