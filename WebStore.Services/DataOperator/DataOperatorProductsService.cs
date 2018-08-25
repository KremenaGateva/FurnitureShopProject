namespace WebStore.Services.DataOperator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using WebStore.Common.DataOperator.BindingModels;
    using WebStore.Common.DataOperator.ViewModels;
    using WebStore.Data;
    using WebStore.Models;
    using WebStore.Services.DataOperator.Interfaces;

    public class DataOperatorProductsService : BaseService, IDataOperatorProductsService
    {
        private readonly IDataOperatorCategoriesService categoryService;

        public DataOperatorProductsService(WebStoreContext context, IMapper mapper,
            IDataOperatorCategoriesService categoryService)
            :base(context, mapper)
        {
            this.categoryService = categoryService;
        }

        public async Task<bool> CreateProductAsync(ProductBindingModel model)
        {
            if (model == null)
            {
                return false;
            }
            var category = await this.categoryService.GetCategoryByNameAsync(model.CategoryName);
            if (category == null)
            {
                category =  await this.categoryService.CreateCategoryAsync(model.CategoryName);
            }

            var product = this.Mapper.Map<Product>(model);
            product.Category = category;

            await this.Context.Products.AddAsync(product);
            await this.Context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await this.GetProductByIdAsync(id);
            if (product == null)
            {
                return false;
            }
            this.Context.Products.Remove(product);
            await this.Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditProductAsync(int id, ProductBindingModel model)
        {
            var product = await this.GetProductByIdAsync(id);
            product.AddedDate = model.AddedDate;
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.QuantityInStock = model.QuantityInStock;
            product.ImagePath = model.ImagePath;
            product.DiscountPercentage = model.DiscountPercentage;

            if (product.Category.Name != model.CategoryName)
            {
                var category = await this.categoryService.GetCategoryByNameAsync(model.CategoryName);
                if (category == null)
                {
                    category = await this.categoryService.CreateCategoryAsync(model.CategoryName);
                }

                product.Category = category;
            }
            await this.Context.SaveChangesAsync();

            return true;
        }

        public async Task<ProductDetailsViewModel> GetProductModelByIdAsync(int id)
        {
            var product = await this.GetProductByIdAsync(id);


            return this.Mapper.Map<ProductDetailsViewModel>(product);
        }

        public async Task<IEnumerable<ProductConciseViewModel>> GetResentlyAddedProductsAsync()
        {
            var products = await this.Context
                .Products
                .OrderByDescending(p => p.AddedDate)
                .Take(20)
                .ToListAsync();

            var productsModels = this.Mapper.Map<IEnumerable<ProductConciseViewModel>>(products);

            return productsModels;
        }

        public ProductBindingModel PrepareProductModelForAdding()
        {
            var model = new ProductBindingModel()
            {
                AddedDate = DateTime.Now,
                DiscountPercentage = 0
            };

            return model;
        }

        public async Task<ProductBindingModel> PrepareProductModelForEditingDeletingAsync(int id)
        {
            var product = await this.Context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            return this.Mapper.Map<ProductBindingModel>(product);
        }

        private async Task<Product> GetProductByIdAsync(int id)
        {
            return await this.Context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
