namespace WebStore.Services.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using WebStore.Common.UserCommon.ViewModels;
    using WebStore.Data;
    using WebStore.Models;
    using WebStore.Services.User.Interfaces;
    using WebStore.Utilities.Constants;

    public class UserOrdersService : BaseService, IUserOrdersService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UserOrdersService(WebStoreContext context,
            IMapper mapper,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
            : base(context, mapper)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<bool> MakeOrderAsync(int id)
        {
            var shoppingCart = await this.Context
                .ShoppingCarts
                .Include(sh => sh.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(sh => sh.Id == id);

            if (shoppingCart == null)
            {
                return false;
            }

            var order = this.CreateNewOrder(shoppingCart);

            shoppingCart.Items.Clear();

            await this.Context.Orders.AddAsync(order);
            await this.Context.SaveChangesAsync();
            return true;
        }

        private Order CreateNewOrder(ShoppingCart shoppingCart)
        {
            var order = new Order()
            {
                CreatorId = shoppingCart.BuyerId,
                OrderDate = DateTime.Now,
                Status = ModelsConstants.StatusConstants.NotConfirmed
            };
            foreach (var item in shoppingCart.Items)
            {
                order.Products.Add(new OrderProduct()
                {
                    Product = item.Product,
                    ProductQuantity = item.Quantity
                });

            }
            order.Price = order.Products.Sum(p => p.Product.QuantityInStock * p.Product.Price);
            return order;
        }

        public IEnumerable<OrderConciseViewModel> GetAllOrdersForCurrentUser()
        {
            var claimsPrincipal = this.signInManager.Context.User;

            var currentUserId = this.userManager.GetUserId(claimsPrincipal);

            var orders = this.Context
                .Orders
                .Include(o => o.Products)
                .Where(o => o.CreatorId == currentUserId);

            return this.Mapper.Map<IEnumerable<OrderConciseViewModel>>(orders);
        }

        public async Task<OrderDetailsViewModel> GetOrderByIdAsync(int id)
        {
            var order = await this.Context.Orders
                .Include(o => o.Products)
                .ThenInclude(op => op.Product)
                .FirstOrDefaultAsync(o => o.Id == id);


            return this.Mapper.Map<OrderDetailsViewModel>(order);
        }
    }
}
