using Microsoft.AspNetCore.Mvc;
using PoetryReader.Core;

namespace PoetryReaderApi.Controllers
{

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IPoetryRepository _poetryRepository;
        private ILogger _logger;

        public ValuesController(IPoetryRepository repo, ILogger logger)
        {
            //TODO: check injected dependencies against NULL
            _poetryRepository = repo;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            return _poetryRepository.GetAPoem();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
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
