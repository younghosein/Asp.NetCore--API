namespace Asp.NetCore_api.Model.Entities
{
    public class AddOrderRequest
    {
        public int OrderAmount { get; set; }


        public long ProductId { get; set; }
     


        public long WarehouseId { get; set; }
    }
}
