namespace WebStore.Services.Anonymous
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using WebStore.Common.Anonymous.ViewModels;
    using WebStore.Data;
    using WebStore.Services.Anonymous.Interfaces;

    public class AnonymousProductsService : BaseService, IAnonymousProductsService
    {
        public AnonymousProductsService(WebStoreContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public async Task<IEnumerable<ProductIndexConciseViewModel>> GetLastTwentyProductsAsync()
        {
            var products = await this.Context.Products
                .OrderByDescending(p => p.AddedDate)
                .Take(20)
                .ToListAsync();

            return this.Mapper.Map<IEnumerable<ProductIndexConciseViewModel>>(products);
        }

        public async Task<ProductIndexDetailsViewModel> GetProductById(int id)
        {
            var product = await this.Context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            return this.Mapper.Map<ProductIndexDetailsViewModel>(product);
        }
    }
}
