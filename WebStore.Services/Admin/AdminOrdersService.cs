namespace WebStore.Services.Admin
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using WebStore.Common.Admin.ViewModels;
    using WebStore.Data;
    using WebStore.Services.Admin.Interfaces;
    using WebStore.Utilities.Constants;

    public class AdminOrdersService : BaseService, IAdminOrdersService
    {
        public AdminOrdersService(WebStoreContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public async Task<ICollection<OrderConciseAdminViewModel>> GetOrdersAsync()
        {
            var orders = await this.Context.Orders
                .Include(o => o.Products)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
            return this.Mapper.Map<ICollection<OrderConciseAdminViewModel>>(orders);
        }

        public async Task<bool> ConfirmOrderAsync(int id)
        {
            var order = await this.Context.Orders.FindAsync(id);
            if (order == null)
            {
                return false;
            }

            order.Status = ModelsConstants.StatusConstants.Confirmed;
            await this.Context.SaveChangesAsync();

            return true;
        }
    }
}
