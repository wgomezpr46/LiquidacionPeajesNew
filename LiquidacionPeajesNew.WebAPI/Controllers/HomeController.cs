using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiquidacionPeajesNew.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [AllowAnonymous]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: api/Home/Get
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Home/Get/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Home/Post
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Home/Put
        [HttpPut("{id}")]
        public void Put([FromBody] string value)
        {
        }

        // DELETE api/Delete/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}