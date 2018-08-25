namespace WebStore.Common.DataOperator.ViewModels
{
    using System.Collections.Generic;

    public class CategoryDetailsViewModel
    {
        public string Name { get; set; }

        public IEnumerable<CategoryProductViewModel> Products { get; set; }
    }
}
