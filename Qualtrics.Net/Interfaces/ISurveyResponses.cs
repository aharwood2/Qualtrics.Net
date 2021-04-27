using Qualtrics.Net.Lang.Requests.SurveyResponses;
using Qualtrics.Net.Lang.Responses.SurveyResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Qualtrics.Net.Interfaces
{
    interface ISurveyResponses
    {
        Task<CreateResponseResponse> CreateResponse(string surveyId, CreateResponseRequest req);

        // TODO: Add other methods from the Survey Responses API
    }
}
