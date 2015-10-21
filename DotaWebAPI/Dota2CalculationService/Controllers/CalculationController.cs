using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataRepo;
using RestSharp;
using RestSharp.Extensions;

namespace Dota2CalculationService.Controllers
{
    public class CalculationController : ApiController
    {
        private readonly DbContext DB;
        public CalculationController()
        {
            //DB = new Dota2DbContext();
        }
        // GET api/calculation
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/calculation/5
        public string Get(int id)
        {
            return "value: "+id;
        }

        // POST api/calculation
        public void Post([FromBody]string value)
        {
        }

        // PUT api/calculation/5
        public void Put(int id, [FromBody]string value)
        {
        }
        public object MyMethod(int id, [FromBody]object value)
        {
            /*
            var client = new RestClient("http://example.com");
            var request = new RestRequest("resource/{id}", Method.GET);
            request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
            request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string

            // or automatically deserialize result
            // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            IRestResponse<object> response2 = client.Execute<object>(request);

            // or download and save file to disk
            client.DownloadData(request).SaveAs("siautuliai.txt");

            // easy async support
            client.ExecuteAsync(request, responsess =>
            {
                Console.WriteLine(responsess.Content);
            });*/
            return new { id, value, kazkas = "Pavyko" };
        }
        // DELETE api/calculation/5
        public void Delete(int id)
        {
        }
    }
}
