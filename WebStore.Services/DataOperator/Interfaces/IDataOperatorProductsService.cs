namespace WebStore.Services.DataOperator.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebStore.Common.DataOperator.BindingModels;
    using WebStore.Common.DataOperator.ViewModels;

    public interface IDataOperatorProductsService
    {
        Task<IEnumerable<ProductConciseViewModel>> GetResentlyAddedProductsAsync();

        Task<bool> CreateProductAsync(ProductBindingModel model);

        Task<ProductDetailsViewModel> GetProductModelByIdAsync(int id);

        Task<ProductBindingModel> PrepareProductModelForEditingDeletingAsync(int id);

        ProductBindingModel PrepareProductModelForAdding();

        Task<bool> EditProductAsync(int id, ProductBindingModel model);

        Task<bool> DeleteProductAsync(int id);
    }
}
