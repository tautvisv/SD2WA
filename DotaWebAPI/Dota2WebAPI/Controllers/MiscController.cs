using System.Web.Http;
using Data;
using DataServices;

namespace Dota2WebAPI.Controllers
{
    [RoutePrefix(Globals.ApiPrefix + "/misc")]
    public class MiscController : BaseController.BaseController
    {
        private readonly IMiscService _service;

        public MiscController(IMiscService service)
        {
            _service = service;
        }
        [Route("AllHeroes")]
        public IHttpActionResult GetAllHeroes()
        {
            return CreateResponse(_service.GetAllHeroes());
        }
        [Route("AllItems")]
        public IHttpActionResult GetAllItems()
        {
            return CreateResponse(_service.GetAllItems());
        }

        [Route("Hero/{id}")]
        public IHttpActionResult GetHero(int id)
        {
            return CreateResponse(_service.GetHero(id));
        }
    }
}
