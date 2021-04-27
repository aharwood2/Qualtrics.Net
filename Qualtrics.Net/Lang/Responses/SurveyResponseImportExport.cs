using System;
using System.Collections.Generic;
using System.Text;

namespace Qualtrics.Net.Lang.Responses.SurveyResponseImportExport
{
    class CreationResponse : Response
    {
        public CreationResponseResult Result { get; internal set; }
    }

    public class CreationResponseResult
    {
        public string ProgressId { get; internal set; }

        public float PercentComplete { get; internal set; }

        public string Status { get; internal set; }

        public string ContinuationToken { get; internal set; }
    }

    public class ExportStatusResponse : Response
    {
        public ExportStatusResult Result { get; internal set; }
    }

    public class ExportStatusResult
    {
        public string FileId { get; internal set; }

        public float PercentComplete { get; internal set; }

        public string Status { get; internal set; }

        public string ContinuationToken { get; internal set; }
    }
}
