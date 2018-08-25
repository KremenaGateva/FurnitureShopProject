namespace WebStore.Common.Anonymous.ViewModels
{
    public class ProductIndexDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal SellPrice { get; set; }

        public decimal Price { get; set; }

        public double DiscountPercentage { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string ImagePath { get; set; }
    }
}
