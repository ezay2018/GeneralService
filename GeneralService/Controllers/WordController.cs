using GeneralService.Models.JSONModel;
using GeneralService.Util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace GeneralService.Controllers
{
    public class WordController : ApiController
    {
        //https://en.wikipedia.org/w/api.php?action=query&format=json&list=search&utf8=1&srsearch=Nelson%20Mandela
        private readonly string endpoint = $"https://en.wikipedia.org/w/api.php?action=query&format=json&list=search&utf8=1&srsearch=";

        // GET: api/Word/word
        public HttpResponseMessage GetMeaning(string word)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            RootObject rootObject = new RootObject();

            //1.0 - make the word parameter url friendly
            word = word?.Replace(" ", "%20");

            //1. access third party api
            var url = endpoint + word?.Trim();

            using (var httpClient = new HttpClient())
            {
                var result = httpClient.GetStringAsync(new Uri(url)).Result;

                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json");

                rootObject = Util.Extract(result);
            }


            return response;
        }

        // GET: api/Word/word
        [Route("api/word/first/{word}")]
        public string GetMeaningSingle(string word)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            RootObject rootObject = new RootObject();

            //1.0 - make the word parameter url friendly
            word = word?.Replace(" ", "%20");

            //1. access third party api
            var url = endpoint + word?.Trim();

            using (var httpClient = new HttpClient())
            {
                var result = httpClient.GetStringAsync(new Uri(url)).Result;

                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json");

                rootObject = Util.Extract(result);
            }

            //2. Get the first response, if any
            var firstResponse = rootObject?.query?.search?.FirstOrDefault()?.snippet;
            if(firstResponse != null)
            {
                firstResponse = HtmlRemoval.StripTagsCharArray(firstResponse);
            }

            return firstResponse;
        }
    }
}
