namespace WebStore.App.Areas.Users.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using WebStore.App.Extensions;
    using WebStore.App.Helpers.Messages;
    using WebStore.Services.User.Interfaces;
    using WebStore.Utilities.Constants;
    using WebStore.Utilities.Messages;

    public class ShoppingCartController : UserController
    {
        private readonly IUserShoppingCartService shoppingCartService;

        public ShoppingCartController(IUserShoppingCartService shoppingCartService)
        {
            this.shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        public async Task<IActionResult> AddItem(int productId)
        {
            try
            {
                if (!await this.shoppingCartService.AddItemToCartAsync(productId))
                {
                    this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
                    {
                        Message = InfoMessages.InsufficientQuantityInStock,
                        Type = MessageType.Warning

                    });
                    return RedirectToPage("/Products/Details", new { id = productId });

                }
            }
            catch (ArgumentException)
            {
                this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
                {
                    Message = InfoMessages.NotFoudRoute,
                    Type = MessageType.Danger

                });
                return RedirectToPage("/Products/Details", new { id = productId });

            }

            this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
            {
                Message = SuccessMessages.AddProductToCart,
                Type = MessageType.Success

            });
            return RedirectToPage("/Products/Details", new { id = productId });
        }

        [HttpGet]
        public async Task<IActionResult> ShowCart()
        {
            var shoppingCartModel = await this.shoppingCartService.GetShoppingCartViewModelAsync();

            return View(shoppingCartModel);
        }

        public async Task<IActionResult> RemoveItem(int id)
        {
            if (!await this.shoppingCartService.RemoveItemAsync(id))
            {
                this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
                {
                    Message = InfoMessages.NotFoudRoute,
                    Type = MessageType.Danger

                });
            }
            this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
            {
                Message = SuccessMessages.RemovedProductFromCart,
                Type = MessageType.Success

            });
            return RedirectToAction("ShowCart", "ShoppingCart", new { area = "Users" });
        }
    }
}