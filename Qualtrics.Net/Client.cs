using Newtonsoft.Json;
using Qualtrics.Net.Interfaces;
using Qualtrics.Net.Lang.Requests;
using Qualtrics.Net.Lang.Requests.SurveyResponses;
using Qualtrics.Net.Lang.Responses;
using Qualtrics.Net.Lang.Responses.SurveyResponses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Qualtrics.Net
{
    sealed class Client : ISurveyResponses
    {
        // Fields
        private HttpClient client;
        private string apiKey;
        private string baseUrl;

        // Singleton Design
        private static readonly Lazy<Client> lazy = new Lazy<Client>(() => new Client());

        /// <summary>
        /// Get an instance of the client
        /// </summary>
        public static Client Instance { get { return lazy.Value; } }

        private Client()
        {
        }

        /// <summary>
        /// Method to initialise the client with the relevant keys
        /// </summary>
        /// <param name="apiKey">API Token from Qualtrics Account</param>
        /// <param name="baseUrl">Base URL for Qualtrics API</param>
        public void Initialise(string apiKey, string baseUrl)
        {
            // Set the keys
            this.apiKey = apiKey;
            this.baseUrl = baseUrl;

            // Create the client
            client = new HttpClient() { BaseAddress = new Uri(baseUrl) };
        }

        // Survey Responses Implementation //

        /// <summary>
        /// 
        /// </summary>
        /// <param name="surveyId"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        public Task<CreateResponseResponse> CreateResponse(string surveyId, CreateResponseRequest req)
        {
            // Build endpoint
            var uri = new Uri($"/API/v3/surveys/{surveyId}/responses", UriKind.Relative);

            // Send
            var res = PostMessage<CreateResponseResponse, CreateResponseRequest>(uri, req);

            // Return the response
            return res;
        }

        // Method to build message and pass back reply
        private async Task<T> PostMessage<T, U>(Uri uri, U req)
            where T : Response
            where U : Request
        {
            // Build content
            string json = JsonConvert.SerializeObject(req);
            var content = new StringContent(json, Encoding.Default, "application/json");

            // Build message
            var message = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = uri,
                Headers =
                {
                    { "x-api-token", apiKey },
                },
                Content = content
            };

            // Send message and return response
            return await SendMessage<T>(message);
        }

        // Method to send and deserialise the reply
        private async Task<T> SendMessage<T>(HttpRequestMessage message)
            where T : Response
        {
            // Send message
            var httpReply = await client.SendAsync(message);

            // Process response
            T resBodyObj = null;
            if (httpReply.IsSuccessStatusCode)
            {
                // Read response
                var resBody = await httpReply.Content.ReadAsStringAsync();

                // Deserialise
                resBodyObj = JsonConvert.DeserializeObject<T>(resBody);
            }
            else
            {
                // TODO: Response should encapsulate the HTTP reply
                Debug.WriteLine($"HTTP FAILED! {httpReply.ReasonPhrase}");
            }
            return resBodyObj;
        }
    }
}
