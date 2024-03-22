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
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Qualtrics.Net.Lang.Responses.SurveyResponseImportExport
{
    public class CreationResponse : Response
    {
        [JsonProperty("result")]
        public CreationResponseResult Result { get; internal set; }
    }

    public class CreationResponseResult
    {
        [JsonProperty("progressId")]
        public string ProgressId { get; internal set; }

        [JsonProperty("percentComplete")]
        public float PercentComplete { get; internal set; }

        [JsonProperty("status")]
        public string Status { get; internal set; }

        [JsonProperty("continuationToken")]
        public string ContinuationToken { get; internal set; }
    }

    public class ExportStatusResponse : Response
    {
        [JsonProperty("result")]
        public ExportStatusResult Result { get; internal set; }
    }

    public class ExportStatusResult
    {
        [JsonProperty("fileId")]
        public string FileId { get; internal set; }

        [JsonProperty("percentComplete")]
        public float PercentComplete { get; internal set; }

        [JsonProperty("status")]
        public string Status { get; internal set; }

        [JsonProperty("continuationToken")]
        public string ContinuationToken { get; internal set; }
    }

    public class ResponseExportFile : Response
    {
        public Stream FileContents { get; internal set; }
    }
}
