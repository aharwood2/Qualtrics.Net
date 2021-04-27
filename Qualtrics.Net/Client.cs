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

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Qualtrics.Net.Interfaces;
using Qualtrics.Net.Lang;
using Qualtrics.Net.Lang.Requests;
using Qualtrics.Net.Lang.Requests.SurveyResponseImportExport;
using Qualtrics.Net.Lang.Requests.SurveyResponses;
using Qualtrics.Net.Lang.Responses;
using Qualtrics.Net.Lang.Responses.Meta;
using Qualtrics.Net.Lang.Responses.SurveyResponseImportExport;
using Qualtrics.Net.Lang.Responses.SurveyResponses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Qualtrics.Net
{
    sealed public class Client : ISurveyResponses, ISurveyResponseImportExport
    {
        // Fields
        private HttpClient client;
        private string apiKey;

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

            // Create the client
            client = new HttpClient() { BaseAddress = new Uri(baseUrl) };
        }

        #region ISurveyResponses

        /// <summary>
        /// 
        /// </summary>
        /// <param name="surveyId"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        public Task<CreateResponseResponse> CreateResponse(string surveyId, CreateResponseRequest req)
        {
            return PostMessage<CreateResponseResponse, CreateResponseRequest>(
                new Uri($"/API/v3/surveys/{surveyId}/responses", UriKind.Relative),
                req
            );
        }

        #endregion

        #region ISurveyResponseImportExport

        /// <summary>
        /// 
        /// </summary>
        /// <param name="surveyId"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        public Task<CreationResponse> StartResponseExport(string surveyId, ExportCreationRequest req)
        {
            return PostMessage<CreationResponse, ExportCreationRequest>(
                new Uri($"/API/v3/surveys/{surveyId}/export-responses", UriKind.Relative),
                req
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exportProgressId"></param>
        /// <param name="surveyId"></param>
        /// <returns></returns>
        public Task<ExportStatusResponse> GetResponseExportProgress(string exportProgressId, string surveyId)
        {
            return GetMessage<ExportStatusResponse>(
                new Uri($"/API/v3/surveys/{surveyId}/export-responses/{exportProgressId}", UriKind.Relative),
                null
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileId"></param>
        /// <param name="surveyId"></param>
        /// <returns></returns>
        public Task<string> GetResponseExportFile(string fileId, string surveyId)
        {
            var res = GetMessage<Response>(
                new Uri($"/API/v3/surveys/{surveyId}/export-responses/{fileId}/file", UriKind.Relative),
                null
            );

            // TODO: Extract file contents?
            return new Task<string>(() => "");
        }

        #endregion

        #region Generics

        // Method to build post message and pass back reply
        private async Task<T> PostMessage<T, U>(Uri uri, U req = null)
            where T : Response, new()
            where U : Request
        {
            // Build message
            var message = GetHttpRequestMessage(uri, HttpMethod.Post);
            if (req != null)
            {
                // Build body content using camelcase resolver
                string json = JsonConvert.SerializeObject(req, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    },
                    NullValueHandling = NullValueHandling.Ignore
                });

                // Add to message
                message.Content = new StringContent(json, Encoding.Default, "application/json");
            }

            // Send message and return response
            return await SendMessage<T>(message);
        }

        private async Task<T> GetMessage<T>(Uri uri, object p)
            where T : Response, new()
        {
            // Build message
            var message = GetHttpRequestMessage(uri, HttpMethod.Get);

            // Send message and return response
            return await SendMessage<T>(message);
        }

        // Method to construct a message
        private HttpRequestMessage GetHttpRequestMessage(Uri uri, HttpMethod method)
        {
            return new HttpRequestMessage
            {
                Method = method,
                RequestUri = uri,
                Headers =
                {
                    { "x-api-token", apiKey },
                }
            };
        }

        // Method to send and deserialise the reply
        private async Task<T> SendMessage<T>(HttpRequestMessage message)
            where T : Response, new()
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
                // Parse HTTP reply to meta
                resBodyObj = new T();
                resBodyObj.Meta = new MetaWithError
                {
                    HttpStatus = ((int)httpReply.StatusCode).ToString(),
                    Error = new Error
                    {
                        ErrorCode = ((int)httpReply.StatusCode).ToString(),
                        ErrorMessage = httpReply.ReasonPhrase
                    }
                };
            }
            return resBodyObj;
        }

        #endregion
    }
}
