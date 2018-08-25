namespace WebStore.App.Areas.DataOperator.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using WebStore.App.Extensions;
    using WebStore.App.Helpers.Messages;
    using WebStore.Services.DataOperator.Interfaces;
    using WebStore.Utilities.Constants;
    using WebStore.Utilities.Messages;

    public class CategoriesController : DataOperatorController
    {
        private readonly IDataOperatorCategoriesService categoriesService;

        public CategoriesController(IDataOperatorCategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public async Task<IActionResult> All()
        {
            var categoriesModel = await this.categoriesService.GetAllCategoriesAsync();
            return View(categoriesModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            
            var model = await this.categoriesService.GetCategoryDetailsModelAsync(id);
            if (model == null)
            {
                this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
                {
                    Message = InfoMessages.NotFoudRoute,
                    Type = MessageType.Info

                });
                return RedirectToAction("Index", "Home", new { area = "DataOperator" });
            }
            return View(model);
        }
    }
}