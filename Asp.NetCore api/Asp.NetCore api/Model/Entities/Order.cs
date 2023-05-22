namespace Asp.NetCore_api.Model.Entities
{
    public class Order
    {
        public long OrderID { get; set; }

        public int OrderAmount { get; set; }

        public long ProductID { get; set; }

     
        public long WarehouseID { get; set; }
    }
}
