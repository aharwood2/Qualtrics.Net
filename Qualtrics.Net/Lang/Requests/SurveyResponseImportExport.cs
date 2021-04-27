using System;
using System.Collections.Generic;
using System.Text;

namespace Qualtrics.Net.Lang.Requests.SurveyResponseImportExport
{
    class ExportCreationRequest : Request
    {
        public string Format { get; set; }

        public bool BreakoutSets { get; set; }

        public bool Compress { get; set; }

        public string EndDate { get; set; }

        public bool ExportResponsesInProgress { get; set; }

        public string FilterId { get; set; }

        public bool FormatDecimalAsComma { get; set; }

        public bool IncludeDisplayOrder { get; set; }

        public int Limit { get; set; }

        public int MultiselectSeenUnansweredRecode { get; set; }

        public string NewlineReplacement { get; set; }

        public int SeenUnansweredRecode { get; set; }

        public string StartDate { get; set; }

        public string TimeZone { get; set; }

        public bool UseLabels { get; set; }

        public string[] EmbeddedDataIds { get; set; }

        public string[] QuestionIds { get; set; }

        public string[] SurveyMetadataIds { get; set; }

        public string ContinuationToken { get; set; }

        public bool AllowContinuation { get; set; }

        public bool IncludeLabelColumns { get; set; }
    }
}
