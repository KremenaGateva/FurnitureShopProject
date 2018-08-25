namespace WebStore.App.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}