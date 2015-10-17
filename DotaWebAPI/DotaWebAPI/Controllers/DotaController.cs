using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace DotaWebAPI.Controllers
{
    public class DotaController : ApiController
    {
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
        public string Post([FromBody]string value)
        {
            return "Post";
        }
        // PUT api/dota/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/dota/5
        public void Delete(int id)
        {
        }
        [HttpPost]
        [ActionName("MyPostas3")]
        public object MyPostass3()
        {
            return new { objektas = "", keistas = "MyPost be ID" };
        }
        public object MyPost(int id, [FromBody]object value)
        {
            return new { objektas = value, keistas = "MyPost" };
        }
        public object MyPost2(int id, [FromBody]object value)
        {
            return new { objektas = value, keistas = "MyPost2" };
        }
        public object MyPost4(string id, [FromBody]object value)
        {
            return new { objektas = value, keistas = "MyPost4: "+id };
        }
    }
}
