using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomCalculationServiceConnectionLib;
using Data;
using Newtonsoft.Json;
using QuandlCS.Connection;
using QuandlCS.Interfaces;
using QuandlCS.Requests;
using QuandlCS.Types;

namespace Dota2WebAPI.Controllers
{
    public class DotaController : ApiController
    {
        //Steam api key: 893F592E19918CA8A9CB5A847C94E2ED
        // GET api/dota
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/dota/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/dota
        public object Post([FromBody]string value)
        {
            return new {value};
        }

        // PUT api/dota/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/dota/5
        public void Delete(int id)
        {
        }

        public object MyPost(int id, [FromBody] object value)
        {
            var request = new QuandlDownloadRequest
            {
                
                APIKey = Globals.APIKey,
                Datacode = new Datacode("PRAGUESE", "PX"),
                Format = FileFormats.JSON,
                Frequency = Frequencies.Monthly,
                Truncation = 150,
                Sort = SortOrders.Ascending,
                Transformation = Transformations.Difference
            };
            IQuandlConnection connection = new QuandlConnection();
            var data = connection.Request(request);
            // PRAGUESE is the source, PX is the datacode

            //Console.WriteLine("The request string is : {0}", request.ToRequestString());
            return new { function = "MyPost(int id, [FromBody] string value)", val = value, data = JsonConvert.DeserializeObject(data) };
        }

        public object Testas(int id, [FromBody] object value)
        {
            var request = new CustomCalculationServiceRequest
            {
                MethodName = "MyMethod",
                MethodController = "Calculation",
                Body = value,
                URLParameters = new[] {"2"},
                MethodType = CustomCalculationServiceRequest.RequestTypeEnum.POST
            };
            CustomCalculationServiceConnection a = new CustomCalculationServiceConnection();
            object response = a.Request(request);
            return new { value, response};
        }
        public object Testas2(int id, [FromBody] object value)
        {
            var request = new CustomCalculationServiceRequest
            {
                MethodName = "",
                MethodController = "Calculation",
                Body = value,
                URLParameters = new[] { "2" },
                MethodType = CustomCalculationServiceRequest.RequestTypeEnum.GET
            };
            CustomCalculationServiceConnection a = new CustomCalculationServiceConnection();
            object response = a.Request(request);
            return new { value, response };
        }
        public object MyPost2(int id, [FromBody] string value)
        {
            QuandlSearchRequest request = new QuandlSearchRequest();
            request.APIKey = "1234-FAKE-KEY-4321";
            request.Format = FileFormats.JSON;
            request.SearchQuery = value;
            IQuandlConnection connection = new QuandlConnection();
            var data = connection.Request(request);
            return new { function = "MyPost2(int id, [FromBody] string value)", val = JsonConvert.DeserializeObject(data) };
        }
        [Route("api/{controller}/MyPostas")]
        public object MyPosta([FromBody] object value)
        {
            return new { function = "MyPosta([FromBody] string value)", value };
        }
    }
}
