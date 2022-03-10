using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WahalafreeAPI.data;
using WahalafreeAPI.Entities;
using WahalafreeAPI.ViewModels;

namespace WahalafreeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private  string  noData = "";
        private WahalaFreeDb db;
        private static string baseUrl = "http://10.0.2.2:38021";
        public RecipeController(WahalaFreeDb wahalaFreeDb)
        {
            db = wahalaFreeDb;
        }
        [HttpGet("getRecipeDetails")]
        public async Task<IActionResult> getRecipeDetails()
        {
           
            var r = await db.recipeDetails.
                Select(s => new  {
                    id = s.id,
                    recipeId = s.recipeid,
                    line1 = string.IsNullOrEmpty(s.line1) ? noData : s.line1,
                    line2 = string.IsNullOrEmpty(s.line2) ? noData : s.line2,
                    line3 = string.IsNullOrEmpty(s.line3) ? noData : s.line3,
                    line4 = string.IsNullOrEmpty(s.line4) ? noData : s.line4,
                    line5 = string.IsNullOrEmpty(s.line5) ? noData : s.line5,
                    line6 = string.IsNullOrEmpty(s.line6) ? noData : s.line6,
                    line7 = string.IsNullOrEmpty(s.line7) ? noData : s.line7,
                    line8 = string.IsNullOrEmpty(s.line8) ? noData : s.line8,
                    line9 = string.IsNullOrEmpty(s.line9) ? noData : s.line9,
                    line10 = string.IsNullOrEmpty(s.line10) ? noData : s.line10,
                })
                . ToListAsync();
            return new JsonResult(r);
        }
        [HttpGet("getRecipeOccasionAsso")]
        public async Task<IActionResult> getRecipeOccasionAsso()
        {
            var r = await db.recipeOccasions
                .Select(s => new
                {
                    occasionId = s.OccasionID,
                    recipeId = s.RecipeID,
                    
                })
                .ToListAsync();
            return new JsonResult(r);
        }
        [HttpGet]
        public async Task<IActionResult> Get() {
            var r = await db.recipes.Select(s => new RecipeViewModel {
                recipeId = s.id,
                name = s.name,
                origin = s.origin,
                subregion = s.subregion,
                imageUrl = baseUrl + s.imageUrl, //baseUrl
                duration = s.duration,
                ingredientCount = s.ingredientcount,
                promoted = s.promoted,
                recipeDes = string.IsNullOrEmpty(s.recipeDes) ? noData : s.recipeDes,
                desDetail = string.IsNullOrEmpty(s.desDetail)? noData : s.desDetail


            }).ToListAsync();
           
          
            return new JsonResult(r);
        }
        [HttpGet("promotion")]
        public async Task<IActionResult> promotion()
        {
            var r = await db.recipes.ToListAsync();
            return new JsonResult(r);
        }

    }
}
