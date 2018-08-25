namespace WebStore.App.Areas.Admin.Pages.Users
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
        private readonly IAdminUsersService usersService;

        public AllModel(IAdminUsersService usersService)
        {
            this.usersService = usersService;
        }

        [BindProperty]
        public IEnumerable<UserConciseViewModel> Users { get; set; }

        public async Task OnGet()
        {
            this.Users = await this.usersService.GetUsersAsync();
        }
    }
}