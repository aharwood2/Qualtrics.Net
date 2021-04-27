using System;
using System.Collections.Generic;
using System.Text;

namespace Qualtrics.Net.Lang.Responses.SurveyResponses
{
    // Create Response Response //

    public class CreateResponseResponse : Response
    {
        public CreateResponseResult Result { get; internal set; }
    }

    public class CreateResponseResult
    {
        public string ResponseId { get; internal set; }
    }

    // TODO: Add more JSON structures for remaining parts of Survey Responses API
}
