using Asp.NetCore_api.Data;
using Asp.NetCore_api.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetCore_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly DataBaseContext dbContext;
        public ProductController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await dbContext.Products.ToListAsync());

        }
        [HttpGet]
        [Route("{ProductID:long}")]
        public async Task<IActionResult> GetProduct([FromRoute]long ProductID) 
        {
            var product = await dbContext.Products.FindAsync(ProductID);
            
            if(product != null) 
            {
                return Ok(product);
            }
            else 
            {
                return NotFound("It doesnt exist on DataBase.");
            }
             
        }

        [HttpPost]

        public async Task<IActionResult> AddProducts(AddProductRequest addProduct)
        {
            var product = new Product()
            {

                ProductName = addProduct.ProductName,
                ProductPrice = addProduct.ProductPrice,
                ProductCode = addProduct.ProductCode,
                ExpireDate = addProduct.ExpireDate,
                stock = addProduct.stock,
                

            };
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            return Ok(product);
        }

        [HttpPut]
        [Route("{ProductID:long}")]

        public async Task<IActionResult> UpdateProduct([FromRoute]long ProductID,UpdateProductRequest upr)
        {
            var product = await dbContext.Products.FindAsync(ProductID);

            if(product != null) 
            {
                product.ProductPrice = upr.ProductPrice;
                product.ProductCode = upr.ProductCode;
                product.stock = upr.stock;

                await dbContext.SaveChangesAsync();

                return Ok(product);
            }

            return NotFound();

        }

        [HttpDelete]
        [Route("{ProductID:long}")]

        public async Task<IActionResult> DeleteProduct([FromRoute]long ProductID)
        {
            var product = await dbContext.Products.FindAsync(ProductID);

            if (product != null) 
            {
                dbContext.Remove(product);
                await dbContext.SaveChangesAsync();
                return Ok(product);
            }
            return NotFound();
        }












    }
}
