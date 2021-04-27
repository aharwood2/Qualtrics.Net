using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualtrics.Net.Lang.Requests.SurveyResponses
{
    // Create Response Request //

    public class CreateResponseRequest : Request
    {
        [JsonProperty("values")]
        public Values Values { get; set; }
    }

    // This will need to be extended based on the survey structure //
    abstract public class Values
    {
        [JsonProperty("distributionChannel")]
        public string DistributionChannel { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("endDate")]
        public string EndDate { get; set; }

        [JsonProperty("finished")]
        public int Finished { get; set; }

        [JsonProperty("locationLatitude")]
        public string Latitude { get; set; }

        [JsonProperty("locationLongitude")]
        public string Longitude { get; set; }

        [JsonProperty("progress")]
        public int Progress { get; set; } = 1;

        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("userLanguage")]
        public string UserLanguage { get; set; }
    }

    // TODO: Add more JSON structures for remaining parts of Survey Responses API
}
