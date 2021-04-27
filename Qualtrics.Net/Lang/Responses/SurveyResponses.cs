using Newtonsoft.Json;
using Qualtrics.Net.Lang.Responses.Meta;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualtrics.Net.Lang.Responses.SurveyResponses
{
    // Create Response Response //

    public class CreateResponseResponse : Response
    {
        [JsonProperty("result")]
        public Result Result { get; internal set; }

        public override bool IsSuccess()
        {
            return Meta.HttpStatusCode == "200";
        }
    }

    public class Result
    {
        [JsonProperty("responseId")]
        public string ResponseId { get; internal set; }
    }

    // TODO: Add more JSON structures for remaining parts of Survey Responses API
}
