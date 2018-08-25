namespace WebStore.Services.DataOperator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using WebStore.Common.DataOperator.ViewModels;
    using WebStore.Data;
    using WebStore.Models;
    using WebStore.Services.DataOperator.Interfaces;

    public class DataOperatorCategoriesService : BaseService, IDataOperatorCategoriesService
    {
        public DataOperatorCategoriesService(WebStoreContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<Category> GetCategoryByNameAsync(string name)
        {
            return await this.Context.Categories.FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<Category> CreateCategoryAsync(string name)
        {
            Category category = null;
            if (!String.IsNullOrEmpty(name) && !String.IsNullOrWhiteSpace(name))
            {
                category = new Category
                {
                    Name = name
                };

                await this.Context.Categories.AddAsync(category);
                await this.Context.SaveChangesAsync();
            }

            return category;
        }

        public async Task<IEnumerable<CategoryConciseViewModel>> GetAllCategoriesAsync()
        {
            var categories = await this.Context.Categories
                .Include(c => c.Products)
                .ToListAsync();

            return this.Mapper.Map<IEnumerable<CategoryConciseViewModel>>(categories);
        }

        public async Task<CategoryDetailsViewModel> GetCategoryDetailsModelAsync(int id)
        {
            var category = await this.Context.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);

            return this.Mapper.Map<CategoryDetailsViewModel>(category);
        }
    }
}
