namespace WebStore.App.Areas.Users.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebStore.Utilities.Constants;

    [Area(AreasConstants.AreaNames.User)]
    [Authorize]
    public abstract class UserController : Controller
    {
    }
}