/*
 * Copyright (C) 2021 Adrian Harwood
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Qualtrics.Net.Lang.Requests.SurveyResponseImportExport
{
    public class ExportCreationRequest : Request
    {
        public string Format { get; set; }

        public bool? BreakoutSets { get; set; }

        public bool? Compress { get; set; } = true;

        public string EndDate { get; set; }

        public bool? ExportResponsesInProgress { get; set; }

        public string FilterId { get; set; }

        public bool? FormatDecimalAsComma { get; set; }

        public bool? IncludeDisplayOrder { get; set; }

        public int? Limit { get; set; }

        public int? MultiselectSeenUnansweredRecode { get; set; }

        public string NewlineReplacement { get; set; }

        public int? SeenUnansweredRecode { get; set; }

        public string StartDate { get; set; }

        public string TimeZone { get; set; }

        public bool? UseLabels { get; set; }

        public string[] EmbeddedDataIds { get; set; }

        public string[] QuestionIds { get; set; }

        public string[] SurveyMetadataIds { get; set; }

        public string ContinuationToken { get; set; }

        public bool? AllowContinuation { get; set; }

        public bool? IncludeLabelColumns { get; set; }
    }
}
