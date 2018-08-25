using System;
namespace WebStore.Common.DataOperator.ViewModels
{
    public class ProductDetailsViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public double DiscountPercentage { get; set; }
          
        public int QuantityInStock { get; set; }

        public string CategoryName { get; set; }

        public string ImagePath { get; set; }

        public DateTime AddedDate { get; set; }
    }
}
