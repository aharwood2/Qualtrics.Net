using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualtrics.Net.Lang.Requests.SurveyResponses
{
    // Create Response Request //

    public class CreateResponseRequest : Request
    {
        public Values Values { get; set; }
    }

    // This will need to be extended based on the survey structure //
    abstract public class Values
    {
        public string DistributionChannel { get; set; }

        public int Duration { get; set; }

        public string EndDate { get; set; }

        public int Finished { get; set; }

        public string LocationLatitude { get; set; }

        public string LocationLongitude { get; set; }

        public int Progress { get; set; } = 1;

        public string StartDate { get; set; }

        public string UserLanguage { get; set; }
    }

    // TODO: Add more JSON structures for remaining parts of Survey Responses API
}
