namespace WebStore.App.Areas.Admin.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using WebStore.Services.Admin.Interfaces;
    using WebStore.Utilities.Constants;

    public class OrdersController : AdminController
    {
        private readonly IAdminOrdersService ordersService;

        public OrdersController(IAdminOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        public async Task<IActionResult> ConfirmOrder(int id)
        {
            if (!await this.ordersService.ConfirmOrderAsync(id))
            {
                return NotFound();
            }

            return RedirectToPage("/Orders/All", new { area = AreasConstants.AreaNames.Administrator});
        }
    }
}