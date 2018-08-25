namespace WebStore.Services.User
{
    using System;
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

    public class UserShoppingCartService : BaseService, IUserShoppingCartService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UserShoppingCartService(
            WebStoreContext context,
            IMapper mapper,
            UserManager<User> userManager,
            SignInManager<User> signInManager) 
            : base(context, mapper)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<bool> AddItemToCartAsync(int productId)
        {
            var product = await this.Context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new ArgumentException();
            }

            if (product.QuantityInStock == 0)
            {
                return false;
            }


            var shoppingCart = await FindOrCreateCurrentUserShoppingCartAsync();

            var shoppingCartItem = shoppingCart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (shoppingCartItem == null)
            {
                shoppingCart.Items.Add(shoppingCartItem = new ShoppingCartItem()
                {
                    ProductId = productId,
                    ShoppingCartId = shoppingCart.Id,
                });

            }

            shoppingCartItem.Quantity++;
            product.QuantityInStock--;
            await this.Context.SaveChangesAsync();
            return true;
        }

        public async Task<ShoppingCartViewModel> GetShoppingCartViewModelAsync()
        {
            var shoppingCart = await this.FindOrCreateShoppingCartWithProductsAsync();
            return this.Mapper.Map<ShoppingCartViewModel>(shoppingCart);
        }


        public async Task<bool> RemoveItemAsync(int id)
        {
            var shoppingCart = await this.FindOrCreateShoppingCartWithProductsAsync();
            var item = shoppingCart.Items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return false;
            }
            item.Product.QuantityInStock++;
            shoppingCart.Items.Remove(item);
            await this.Context.SaveChangesAsync();

            return true;
        }

        private async Task<ShoppingCart> FindShoppingCartWithItemsAsync()
        {
            var claimsPrincipal = this.signInManager.Context.User;

            var currentUserId = this.userManager.GetUserId(claimsPrincipal);

            var shoppingCart = await this.Context.ShoppingCarts
                .Include(sh => sh.Items)
                .FirstOrDefaultAsync(sh => sh.BuyerId == currentUserId);

            return shoppingCart;
        }

        private async Task<ShoppingCart> FindOrCreateShoppingCartWithProductsAsync()
        {
            var claimsPrincipal = this.signInManager.Context.User;

            var currentUserId = this.userManager.GetUserId(claimsPrincipal);

            var shoppingCart = await this.Context.ShoppingCarts
                .Include(sh => sh.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(sh => sh.BuyerId == currentUserId);

            if (shoppingCart == null)
            {
                await CreateShoppingCartAsync(currentUserId);

            }

            return shoppingCart;
        }

        private async Task<ShoppingCart> FindOrCreateCurrentUserShoppingCartAsync()
        {
            var claimsPrincipal = this.signInManager.Context.User;

            var currentUserId = this.userManager.GetUserId(claimsPrincipal);

            var shoppingCart = await this.Context.ShoppingCarts
                .Include(sh => sh.Buyer)
                .Include(sh => sh.Items)
                .FirstOrDefaultAsync(sh => sh.BuyerId == currentUserId);

            if (shoppingCart == null)
            {
                await CreateShoppingCartAsync(currentUserId);

            }

            return shoppingCart;
        }

        private async Task CreateShoppingCartAsync(string currentUserId)
        {
            var shoppingCart = new ShoppingCart()
            {
                BuyerId = currentUserId
            };

            await this.Context.ShoppingCarts.AddAsync(shoppingCart);
            await this.Context.SaveChangesAsync();
        }
    }
}
