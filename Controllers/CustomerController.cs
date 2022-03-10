using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WahalafreeAPI.data;
using WahalafreeAPI.ViewModels;
using WahalafreeAPI.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WahalafreeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase

    {
        private ILogger<CustomerController> _logger;
        private WahalaFreeDb _WahalaFreeDb;

        public CustomerController( ILogger<CustomerController> logger, WahalaFreeDb db)
        {
            this._WahalaFreeDb = db;
            this._logger = logger;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerViewModel customerViewModel)
        {
            var user = new Customer();
            user.CustomerEmail = customerViewModel.CustomerEmail;
            user.Title = customerViewModel.Title;
            user.FirstName = customerViewModel.FirstName;
            user.SurName = customerViewModel.SurName;
          
            this._WahalaFreeDb.customers.Add(user);
            if (this._WahalaFreeDb.SaveChanges() > 0)
            {

                return Created($"{user.ID}", user);
            }
            return BadRequest(this.StatusCode(500, "Your Registration Failed Try Latter"));
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
