using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualtrics.Net.Lang.Responses.Meta
{
    // Meta with error
    public class MetaWithError
    {
        [JsonProperty("httpStatus")]
        public string HttpStatusCode { get; internal set; }

        [JsonProperty("requestId")]
        public string RequestId { get; internal set; }

        [JsonProperty("notice")]
        public string Notice { get; internal set; }

        [JsonProperty("error")]
        public Error Error { get; internal set; }
    }

    // Error
    public class Error
    {
        [JsonProperty("errorMessage")]
        public string Message { get; internal set; }

        [JsonProperty("errorCode")]
        public string Code { get; internal set; }
    }
}
