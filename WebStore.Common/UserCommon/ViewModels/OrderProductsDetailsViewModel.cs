namespace WebStore.Common.UserCommon.ViewModels
{
    public class OrderProductsDetailsViewModel
    {
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return this.Quantity * Price;
            }
        }
    }
}