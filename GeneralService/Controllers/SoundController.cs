using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GeneralService.Controllers
{
    public class SoundController : ApiController
    {
        // GET: api/Sound
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Sound/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Sound
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Sound/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sound/5
        public void Delete(int id)
        {
        }
    }
}
