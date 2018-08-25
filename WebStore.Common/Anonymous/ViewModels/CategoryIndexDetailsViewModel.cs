namespace WebStore.Common.Anonymous.ViewModels
{
    using System.Collections.Generic;

    public class CategoryIndexDetailsViewModel
    {
        public string Name { get; set; }

        public int ProductsCount { get; set; }

        public IEnumerable<ProductIndexConciseViewModel> Products { get; set; }
    }
}
