namespace Asp.NetCore_api.Model.Entities
{
    public class UpdateOrderRequest
    {
        public int OrderAmount { get; set; }

        public long ProductID { get; set; }

        public long WarehouseID { get; set; }
    }
}
