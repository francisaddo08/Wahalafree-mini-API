using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WahalafreeAPI.data;
using WahalafreeAPI.Entities;

namespace WahalafreeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccasionController : ControllerBase
    {
        private WahalaFreeDb cx;
        private static string baseUrl = "http://10.0.2.2:38021";
        public OccasionController( WahalaFreeDb db)
        {
            this.cx = db;

        }
        [HttpGet]
        public async Task<IActionResult> Get() {
            var r = await cx.occasions.Select(s => new  {
                occasionId = s.id,
                name = s.name,
                imageUrl = baseUrl + s.imageUrl,
                promoted = s.promoted
                


            }).ToListAsync();
            return new JsonResult(r);
        
        
        
        }
    }
}
