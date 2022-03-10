using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WahalafreeAPI.data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WahalafreeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryCostController : ControllerBase
    {
        private WahalaFreeDb db;
        private ILogger<DeliveryCostController> _logger;
        public DeliveryCostController(WahalaFreeDb wahalaFreedb,
            ILogger<DeliveryCostController> logger) {
            this.db = wahalaFreedb;
            this._logger = logger;
        }
        // GET: api/<DeliveryCostController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var r = await db.deliveryCosts.ToListAsync();
            return new JsonResult(r);
        }

        // GET api/<DeliveryCostController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DeliveryCostController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DeliveryCostController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DeliveryCostController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
