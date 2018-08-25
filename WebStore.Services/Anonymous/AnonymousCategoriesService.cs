namespace WebStore.Services.Anonymous
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using WebStore.Common.Anonymous.ViewModels;
    using WebStore.Data;
    using WebStore.Services.Anonymous.Interfaces;

    public class AnonymousCategoriesService : BaseService, IAnonymousCategoriesService
    {
        public AnonymousCategoriesService(WebStoreContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public async Task<IEnumerable<CategoryIndexConciseViewModel>> GetAllCategoriesAlphabeticallyAsync()
        {
            var categoriesAlphabetically = await this.Context.Categories.OrderBy(c => c.Name).ToListAsync();

            return this.Mapper.Map<IEnumerable<CategoryIndexConciseViewModel>>(categoriesAlphabetically);
        }

        public async Task<CategoryIndexDetailsViewModel> GetCategoryByIdAsync(int id)
        {
            var category = await this.Context.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);

            return this.Mapper.Map<CategoryIndexDetailsViewModel>(category);
        }
    }
}
