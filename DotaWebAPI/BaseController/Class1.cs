using System.Web.Http;

namespace BaseController
{
    public class BaseController : ApiController
    {
        protected IHttpActionResult CreateResponse(object obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
    }
}
