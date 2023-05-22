namespace Asp.NetCore_api.Model.Entities
{
    public class AddProductRequest
    {
        public string ProductName { set; get; }
        public int ProductPrice { set; get; }
        public DateTime ExpireDate { set; get; }
        public int ProductCode { set; get; }
        public int stock { set; get; }


    }
}
