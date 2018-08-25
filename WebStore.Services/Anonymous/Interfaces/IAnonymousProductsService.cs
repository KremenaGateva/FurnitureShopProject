namespace WebStore.Services.Anonymous.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebStore.Common.Anonymous.ViewModels;

    public interface IAnonymousProductsService
    {
        Task<IEnumerable<ProductIndexConciseViewModel>> GetLastTwentyProductsAsync();

        Task<ProductIndexDetailsViewModel> GetProductById(int id);
    }
}
