using System.Threading;
using Microsoft.AspNetCore.Mvc;
using PoetryReader.Api.Repository;

namespace PoetryReader.Api.Controllers
{

    [Route("api/[controller]")]
    public class PoetryController : Controller
    {
        private readonly IPoetryReader _poetryReader;

        public PoetryController(IPoetryReader poetryReader)
        {
            _poetryReader = poetryReader;
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            return _poetryReader.GetAPoem();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id, CancellationToken cancellationToken)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
