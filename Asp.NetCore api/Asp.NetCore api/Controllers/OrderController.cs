using Asp.NetCore_api.Data;
using Asp.NetCore_api.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetCore_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly DataBaseContext dbContext;
        public OrderController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await dbContext.Order.ToListAsync());

        }
        [HttpGet]
        [Route("{OrderID:long}")]
        public async Task<IActionResult> GetWarehouse([FromRoute] long OrderID)
        {
            var order = await dbContext.Order.FindAsync(OrderID);

            if (order != null)
            {
                return Ok(order);
            }
            else
            {
                return NotFound("It doesnt exist on DataBase.");
            }

        }
        [HttpPost]
        [Route("{OrderID:long}")]
        public async Task<IActionResult> AddOrder(AddOrderRequest addorder)
        {
            var order = new Order()
            {
                OrderAmount = addorder.OrderAmount,
              
                ProductID = addorder.ProductId,
                WarehouseID= addorder.WarehouseId

            };
            await dbContext.Order.AddAsync(order);
            await dbContext.SaveChangesAsync();

            return Ok(order);
        }
        [HttpPut]
        [Route("{OrderID:long}")]

        public async Task<IActionResult> UpdateWarehouse([FromRoute] long OrderID, UpdateOrderRequest uor)
        { 
            var order = await dbContext.Order.FindAsync(OrderID);

            if (order != null)
            {
                order.WarehouseID = uor.WarehouseID;
                order.OrderAmount = uor.OrderAmount;
                order.ProductID = uor.ProductID;

                await dbContext.SaveChangesAsync();

                return Ok(order);
            }

            return NotFound();

        }
        [HttpDelete]
        [Route("{OrderID:long}")]

        public async Task<IActionResult> DeleteOrder([FromRoute] long OrderID)
        {
            var order = await dbContext.Order.FindAsync(OrderID);

            if (order != null)
            {
                dbContext.Remove(order);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }

    }
}
