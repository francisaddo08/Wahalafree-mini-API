using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WahalafreeAPI.data;
using WahalafreeAPI.Entities;
using WahalafreeAPI.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WahalafreeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILogger<UserController> _logger;
        private WahalaFreeDb _WahalaFreeDb;
        public UserController(WahalaFreeDb db, ILogger<UserController> logger)
        {
            this._WahalaFreeDb = db;
            this._logger = logger;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] RegisterViewModel userModel)
        {
            var user = new RegisterCustomer();
            user.Email = userModel.Email;
            user.Password = userModel.Password;
            user.CreatedOn = DateTime.Now;
            this._WahalaFreeDb.registerCustomers.Add(user);
            if(this._WahalaFreeDb.SaveChanges() > 0)
            {
                var uvm = new RegisterViewModel();
              
                uvm.Email = user.Email;
                uvm.Password = user.Password;
             
                return Created($"{user.ID}", user);
            }
            return BadRequest(this.StatusCode(500, "Your Registration Failed Try Latter"));
        }
//---------------------------------------------------------------------------------------------------
        [HttpPost("/postCustomer")]
        public IActionResult postCustomer([FromBody] CustomerViewModel customerViewModel)
        {
            var user = new Customer();
            user.Title = customerViewModel.Title;
            user.CustomerEmail = customerViewModel.CustomerEmail;
            user.FirstName = customerViewModel.FirstName;
            user.SurName = customerViewModel.SurName;
            this._WahalaFreeDb.customers.Add(user);
            if  (  this._WahalaFreeDb.SaveChanges() > 0)
            {

                return  Created($"{user.ID}", user);
            }
            return BadRequest(this.StatusCode(500, "Your Registration Failed Try Latter"));
        }





        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
