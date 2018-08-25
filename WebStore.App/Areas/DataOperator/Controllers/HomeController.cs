namespace WebStore.App.Areas.DataOperator.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using WebStore.Services.DataOperator.Interfaces;

    public class HomeController : DataOperatorController
    {
        private readonly IDataOperatorProductsService productService;

        public HomeController(IDataOperatorProductsService productService) 
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var recentProducts = await this.productService.GetResentlyAddedProductsAsync();

            return View(recentProducts);
        }
    }
}
