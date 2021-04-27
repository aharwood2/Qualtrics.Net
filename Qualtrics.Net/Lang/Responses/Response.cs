using Newtonsoft.Json;
using Qualtrics.Net.Lang.Responses.Meta;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualtrics.Net.Lang.Responses
{
    // Response base class
    public abstract class Response
    {
        [JsonProperty("meta")]
        public MetaWithError Meta { get; internal set; }

        // Not part of API
        public abstract bool IsSuccess();
    }
}
