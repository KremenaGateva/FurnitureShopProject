namespace WebStore.Services.DataOperator.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebStore.Common.DataOperator.ViewModels;
    using WebStore.Models;

    public interface IDataOperatorCategoriesService
    {
        Task<Category> GetCategoryByNameAsync(string name);
        Task<Category> CreateCategoryAsync(string name);
        Task<IEnumerable<CategoryConciseViewModel>> GetAllCategoriesAsync();
        Task<CategoryDetailsViewModel> GetCategoryDetailsModelAsync(int id);
    }
}
