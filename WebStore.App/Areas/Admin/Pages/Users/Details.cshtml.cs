namespace WebStore.App.Areas.Admin.Pages.Users
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using WebStore.Common.Admin.ViewModels;
    using WebStore.Services.Admin.Interfaces;
    using WebStore.Utilities.Constants;

    [Area(AreasConstants.AreaNames.Administrator)]
    [Authorize(Roles = RolesConstants.RoleNames.Administrator)]
    public class DetailsModel : PageModel
    {
        private readonly IAdminUsersService usersService;

        public DetailsModel(IAdminUsersService usersService)
        {
            this.usersService = usersService;
        }

        [BindProperty]
        public UserDetailsViewModel UserModel { get; set; }

        public async Task<IActionResult> OnGet(string id)
        {
            if (!this.usersService.CheckIfAuthorized(id))
            {
                return Unauthorized();
            }
            this.UserModel = await this.usersService.GetUserModelById(id);

            if (this.UserModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}