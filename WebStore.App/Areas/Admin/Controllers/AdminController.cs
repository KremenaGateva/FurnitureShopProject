namespace WebStore.App.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebStore.Utilities.Constants;

    [Area(AreasConstants.AreaNames.Administrator)]
    [Authorize(Roles = RolesConstants.RoleNames.Administrator)]
    public abstract class AdminController : Controller
    {
    }
}
