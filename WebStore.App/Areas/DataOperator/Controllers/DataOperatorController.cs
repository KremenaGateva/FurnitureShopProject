namespace WebStore.App.Areas.DataOperator.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebStore.Utilities.Constants;

    [Area(AreasConstants.AreaNames.DataOperator)]
    [Authorize(Roles = RolesConstants.RoleNames.DataOperator)]
    public abstract class DataOperatorController : Controller
    {
    }
}
