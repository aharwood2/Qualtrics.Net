using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualtrics.Net.Lang.Requests.SurveyResponses
{
    // Create Response Request //

    internal class CreateResponseRequest : Request
    {
        [JsonProperty("values")]
        internal Values Values { get; set; }
    }

    // This will need to be extended based on the survey structure //
    abstract public class Values
    {
        [JsonProperty("distributionChannel")]
        internal string DistributionChannel { get; set; }

        [JsonProperty("duration")]
        internal int Duration { get; set; }

        [JsonProperty("endDate")]
        internal string EndDate { get; set; }

        [JsonProperty("finished")]
        internal int Finished { get; set; }

        [JsonProperty("locationLatitude")]
        internal string Latitude { get; set; }

        [JsonProperty("locationLongitude")]
        internal string Longitude { get; set; }

        [JsonProperty("progress")]
        internal int Progress { get; set; } = 1;

        [JsonProperty("startDate")]
        internal string StartDate { get; set; }

        [JsonProperty("userLanguage")]
        internal string UserLanguage { get; set; }
    }

    // TODO: Add more JSON structures for remaining parts of Survey Responses API
}
