using System.Collections.Generic;
using System.Web.Http;
using CalculationServicesInterfaces;
using Data;
using DatabaseEntities.Entities;
using Validation;

namespace Dota2CalculationService.Controllers
{
    [RoutePrefix(Globals.ApiPrefix + "/Calculation")]
    public class CalculationController : BaseController.BaseController
    {
        private readonly IStatisticsCalculationService _service;
        private readonly IKeyValidation _keyValidation;
        public CalculationController(IStatisticsCalculationService service, IKeyValidation validation)
        {
            _service = service;
            _keyValidation = validation;
            //DB = new Dota2DbContext();
        }
        [Route("key/{key}/Statistics/")]
        public IHttpActionResult PostCalculateStatistics(string key, [FromBody]Match match)
        {
            if (!_keyValidation.IsValid(key))
            {
                return null;
            }
            var result = _service.CalculateStatistics(match);
            return CreateResponse(result);
        }
        [Route("key/{key}/Winrate/")]
        public IHttpActionResult PostCalculateWinrate(string key, [FromBody]ICollection<Match> matches)
        {
            if (!_keyValidation.IsValid(key))
            {
                return CreateResponse(null);
            }
            var result = _service.CalculateWinrate(matches);
            return CreateResponse(result);
        }

        [Route("key/{key}/Rating/PlayerID/{id}")]
        public IHttpActionResult PostCalculateRating(string key, int id, [FromBody]ICollection<Match> matches)
        {
            if (!_keyValidation.IsValid(key))
            {
                return null;
            }
            var result = _service.CalculateRating(matches, id);
            return CreateResponse(result);
        }

        [Route("key/{key}/Best/")]
        public IHttpActionResult PostCalculateBestAgainst(string key, [FromBody]ICollection<Match> matches)
        {
            if (!_keyValidation.IsValid(key))
            {
                return CreateResponse(null);
            }
            var result = _service.CalculateBestAgainst(matches);
            return CreateResponse(result);
        }
        [Route("key/{key}/Worst/")]
        public IHttpActionResult PostCalculateWorstAgainst(string key, [FromBody]ICollection<Match> matches)
        {
            if (!_keyValidation.IsValid(key))
            {
                return CreateResponse(null);
            }
            var result = _service.CalculateWorstAgainst(matches);
            return CreateResponse(result);
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
