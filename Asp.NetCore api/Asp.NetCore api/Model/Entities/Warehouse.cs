namespace Asp.NetCore_api.Model.Entities
{
    public class Warehouse
    {
        public long WarehouseID { get; set; }

        public string WarehouseAddress { get; set; }

        public string WarehouseName { get; set; }

        public Order Order { get; set; }


    }
}
