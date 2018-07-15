using System.Collections.Generic;
using System.Linq;
using HelloAKS.Databases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HelloAKS.Controllers
{
    public class DataModel
    {
        public string Key { get;set; }
        public string Data { get;set; }
    }

    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private IDatabase _db;

        public DataController(IConfiguration config, IDatabase db)
        {
            _db = db;    
        }

        // GET api/data
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<DataModel> allData = _db.GetAllData().Select(kvp => new DataModel() { Key = kvp.Key, Data = kvp.Value });

            return Ok(allData);
        }

        // GET api/data/{key}
        [HttpGet("{key}")]
        public IActionResult Get(string key)
        {
            if (_db.TryGetData(key, out string data))
            {
                return Ok(new DataModel() { Key = key, Data = data });
            }

            return BadRequest();
        }

        // PUT api/data/{key}
        [HttpPut("{key}")]
        public IActionResult Put(string key, [FromBody]DataModel value)
        {
            _db.PutData(key, value.Data);

            return Created($"/api/data/{key}", null);
        }

        // DELETE api/data/{key}
        [HttpDelete("{key}")]
        public IActionResult Delete(string key)
        {
            _db.DeleteData(key);

            return Accepted();
        }
    }
}
