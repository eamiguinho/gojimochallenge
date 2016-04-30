using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GojimoChallenge.Contracts.Results;
using Newtonsoft.Json;

namespace GojimoChallenge.DataServices.Implementation.Helpers
{
    public static class OnlineHelper
    {
        public static HttpClient GetHttpClient(string eTag = null)
        {
            var handler = new HttpClientHandler();
            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = DecompressionMethods.GZip |
                                                 DecompressionMethods.Deflate;
            }
            var client = new HttpClient(handler) { Timeout = new TimeSpan(0, 1, 0) };

            if (!string.IsNullOrWhiteSpace(eTag))
            {
                client.DefaultRequestHeaders.Add("If-None-Match", eTag); 
            }
            return client;
        }

        public static async Task<DataResult<T>> CallAPI<T>(string url, string eTag)
        {
            var client = GetHttpClient(eTag);
            var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, new Uri(url)));
            if (response.IsSuccessStatusCode)
            {
                var objectReceived = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                return new DataResult<T>(objectReceived, response.Headers.ETag.Tag);
            }
            if (response.StatusCode == HttpStatusCode.NotModified)
            {
                return new DataResult<T>(Result.NotAuthorized);
            }
            return new DataResult<T>(Result.Error);
        }

        public static string BaseAddress { get { return "https://api.gojimo.net/api/v4/"; } }
        public static string QualificationRoute { get { return "qualifications"; } }
    }
}
