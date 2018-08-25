namespace WebStore.Common.Anonymous.ViewModels
{
    public class ProductIndexConciseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public decimal SellPrice { get; set; }

        public decimal Price { get; set; }

        public double DiscountPercentage { get; set; }

        public string ImagePath { get; set; }
    }
}
