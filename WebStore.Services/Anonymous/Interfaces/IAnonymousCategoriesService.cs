namespace WebStore.Services.Anonymous.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebStore.Common.Anonymous.ViewModels;

    public interface IAnonymousCategoriesService
    {
        Task<IEnumerable<CategoryIndexConciseViewModel>> GetAllCategoriesAlphabeticallyAsync();
        Task<CategoryIndexDetailsViewModel> GetCategoryByIdAsync(int id);
    }
}
