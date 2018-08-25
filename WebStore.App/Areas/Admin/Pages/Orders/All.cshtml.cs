namespace WebStore.App.Areas.Admin.Pages.Orders
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using WebStore.Common.Admin.ViewModels;
    using WebStore.Services.Admin.Interfaces;
    using WebStore.Utilities.Constants;

    [Area(AreasConstants.AreaNames.Administrator)]
    [Authorize(Roles = RolesConstants.RoleNames.Administrator)]
    public class AllModel : PageModel
    {
        private readonly IAdminOrdersService ordersService;

        public AllModel(IAdminOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        [BindProperty]
        public ICollection<OrderConciseAdminViewModel> Orders { get; set; }

        public async Task OnGet()
        {
            this.Orders = await this.ordersService.GetOrdersAsync();
        }
    }
}