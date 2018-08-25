namespace WebStore.App.Areas.Users.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using WebStore.App.Extensions;
    using WebStore.App.Helpers.Messages;
    using WebStore.Services.User.Interfaces;
    using WebStore.Utilities.Constants;
    using WebStore.Utilities.Messages;

    public class OrdersController : UserController
    {
        private readonly IUserOrdersService ordersService;

        public OrdersController(IUserOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }
        public async Task<IActionResult> MakeOrder(int id)
        {
            if (!await this.ordersService.MakeOrderAsync(id))
            {
                this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
                {
                    Message = InfoMessages.UnableToFinishOrder,
                    Type = MessageType.Warning

                });

            }
            this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
            {
                Message = SuccessMessages.FinishedOrder,
                Type = MessageType.Success

            });
            return RedirectToPage("/Index");
        }

        public IActionResult All()
        {
            var models = this.ordersService.GetAllOrdersForCurrentUser();
            return View(models);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await this.ordersService.GetOrderByIdAsync(id);
            if (model == null)
            {
                this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
                {
                    Message = InfoMessages.NotFoudRoute,
                    Type = MessageType.Info

                });

                return RedirectToPage("/Index");
            }
            return View(model);
        }
    }
}