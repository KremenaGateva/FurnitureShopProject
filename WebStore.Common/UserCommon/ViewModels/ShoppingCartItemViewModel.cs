namespace WebStore.Common.UserCommon.ViewModels
{
    public class ShoppingCartItemViewModel
    {
        public int Id { get; set; }

        public string ItemName { get; set; }

        public string ImagePath { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice
        {
            get
            {
               return this.Quantity * this.Price;
            }
        }
    }
}
