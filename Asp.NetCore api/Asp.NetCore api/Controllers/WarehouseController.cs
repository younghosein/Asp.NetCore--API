using Asp.NetCore_api.Data;
using Asp.NetCore_api.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetCore_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : Controller
    {
        private readonly DataBaseContext dbContext;
        public WarehouseController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetWarehouses()
        {
            return Ok(await dbContext.Warehouses.ToListAsync());

        }

        [HttpGet]
        [Route("{WarehouseID:long}")]
        public async Task<IActionResult> GetWarehouse([FromRoute] long WarehouseID)
        {
            var warehouse = await dbContext.Warehouses.FindAsync(WarehouseID);

            if (warehouse != null)
            {
                return Ok(warehouse);
            }
            else
            {
                return NotFound("It doesnt exist on DataBase.");
            }

        }

        [HttpPost]
        [Route("{WarehouseID:long}")]
        public async Task<IActionResult> AddWareHouse(AddWareHouseRequest addwarehouse)
        {
            var warehouse = new Warehouse()
            {
                WarehouseAddress = addwarehouse.WarehouseAddress,
                WarehouseName = addwarehouse.WarehouseName,
                
            };
            await dbContext.Warehouses.AddAsync(warehouse);
            await dbContext.SaveChangesAsync();

            return Ok(warehouse);
        }

        [HttpPut]
        [Route("{WarehouseID:long}")]

        public async Task<IActionResult> UpdateWarehouse([FromRoute] long WarehouseID, UpdateWarehouseRequest uwr)
        {
            var warehouse = await dbContext.Warehouses.FindAsync(WarehouseID);

            if ( warehouse != null)
            {
                warehouse.WarehouseAddress = uwr.WarehouseAddress;
                warehouse.WarehouseName = uwr.WarehouseName;

                await dbContext.SaveChangesAsync();

                return Ok(warehouse);
            }

            return NotFound();

        }

        [HttpDelete]
        [Route("{WarehouseID:long}")]

        public async Task<IActionResult> DeleteWarehouse([FromRoute] long WarehouseID)
        {
            var warehouse = await dbContext.Warehouses.FindAsync(WarehouseID);

            if (warehouse != null)
            {
                dbContext.Remove(warehouse);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }

    }
}
