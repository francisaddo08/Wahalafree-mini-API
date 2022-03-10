using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WahalafreeAPI.ViewModels;
using WahalafreeAPI.Entities;
using WahalafreeAPI.data;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WahalafreeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        

        private ILogger<ProductCategoryController> _logger;
        private WahalaFreeDb _WahalaFreeDb;
       public ProductCategoryController(ILogger<ProductCategoryController> logger, WahalaFreeDb cx)
        {
            _logger = logger;
            _WahalaFreeDb = cx;
        }
//=====================================CATEGORY PRODUCT CROSS REF====================================================
       [HttpGet("getProdCatAssoList")]
        public async Task<IActionResult> getProdCatAssoList()
        {
            var r = await _WahalaFreeDb.productCategories
                .Select(s => new ProductCategoryAsso { 
                         productId = s.ProductID,
                         categoryId = s.CategoryID
                })
                .ToListAsync();
            return new JsonResult(r);
        }
        //================================PRODUCT OCCASION CROSS REF================================================
        [HttpGet("getProductOccasionAsso")]
        public async Task<IActionResult> getProductOccasionAsso()
        {
            var r = await _WahalaFreeDb.productOccasions
                .Select(s => new 
                {
                    productId = s.ProductID,
                    occasionId = s.OccasionID
                })
                .ToListAsync();
            return new JsonResult(r);
        }
        //=================================PRODUCT RECIPE CROSS REF=================================================
        [HttpGet("getProductRecipeAsso")]
        public async Task<IActionResult> getProductRecipeAsso()
        {
            var r = await _WahalaFreeDb.productRecicpes
                .Select(s => new
                {
                    productId = s.ProductID,
                    recipeId = s.RecipeID
                })
                .ToListAsync();
            return new JsonResult(r);
        }
        //===============================================================================
      
        //==================================LIST ALL CATEGORIES===========================================
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var r = await _WahalaFreeDb.categories
                .Select(s => new CategoryViewModel {
                    categoryId = s.id,
                    name = s.name,
                    imageUrl = s.imageUrl
                })
                .ToListAsync();

            
            return new JsonResult(r);
        }
      //=============================LIST ALL PRODUCTS==========================================
        [HttpGet("getProducts")]
        public async Task<IActionResult> getProducts()
        {
          
            var r = await _WahalaFreeDb.products
                .Select(s => new ProductViewModel 
                {
                   productId = s.id,
                   name = s.name,
                   imageUrl = s.imageUrl,
                   price = s.price,
                   stockLevel = s.stockLevel,
                   justLanded = s.justLanded.ToString().ToLower(),
                    productDesc = s.pdesc
                }
                ).ToListAsync();
            
            
            return new JsonResult(r);
        }
        //============================PRODUCT BY NAME================================================
        [HttpGet("getProductName")]
        public string getProductName()
        {
            return "server product name";
        }
     //============================PRODUCTS BY CATEGORY===================================================
        [HttpGet("getProductsByCategory/{id}")]
         public async Task<IActionResult> getProductsByCategory(string id)
         {
            var r = await _WahalaFreeDb.productCategories
                .Where(pc => pc.CategoryID == id).ToListAsync();

            List<Guid> guids = new List<Guid>();
            List<ProductViewModel> products = new List<ProductViewModel>();
            foreach(ProductCategory pc in r)
            {
                guids.Add(pc.ProductID);
                ProductViewModel p = await _WahalaFreeDb.products.Where(p => p.id == pc.ProductID)
                    .Select(s => new ProductViewModel
                    {
                        productId = s.id,
                        name = s.name,
                        imageUrl = s.imageUrl,
                        stockLevel = s.stockLevel,
                        price = s.price,
                        justLanded = s.justLanded.ToString(),
                        productDesc = s.pdesc
                    })
                    .SingleOrDefaultAsync();
                products.Add(p);
            }
            
            return new JsonResult(products);
        }

        // GET api/<ProductCategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductCategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductCategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductCategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
