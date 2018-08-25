namespace WebStore.App.Areas.DataOperator.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using WebStore.App.Extensions;
    using WebStore.App.Helpers.Messages;
    using WebStore.Common.DataOperator.BindingModels;
    using WebStore.Services.DataOperator.Interfaces;
    using WebStore.Utilities.Constants;
    using WebStore.Utilities.Messages;

    public class ProductsController : DataOperatorController
    {
        private readonly IDataOperatorProductsService productService;

        public ProductsController(IDataOperatorProductsService productService) 
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = this.productService.PrepareProductModelForAdding();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
                {
                    Message = ErrorMessages.Models.InvalidModelStateMessage,
                    Type = MessageType.Danger
                    
                });

                return RedirectToAction("Add", "Products", new { area = "dataOperator" });
            }

            if (!await this.productService.CreateProductAsync(model))
            {
                this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
                {
                    Message = InfoMessages.UnableToAddNewProduct,
                    Type = MessageType.Danger

                });

                return RedirectToAction("Add", "Products", new { area = "dataOperator" });
            }

            return RedirectToAction("Index", "Home", new { area = "DataOperator"});
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await this.productService.GetProductModelByIdAsync(id);
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.productService.PrepareProductModelForEditingDeletingAsync(id);

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

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
                {
                    Message = ErrorMessages.Models.InvalidModelStateMessage,
                    Type = MessageType.Danger

                });

                return RedirectToAction("Add", "Products", new { area = "dataOperator" });
            }

            if (!await this.productService.EditProductAsync(id, model))
            {
                this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
                {
                    Message = InfoMessages.UnableToEditProduct,
                    Type = MessageType.Danger

                });

                return RedirectToAction("Add", "Products", new { area = "dataOperator" });
            }

            this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
            {
                Message = SuccessMessages.EditProduct,
                Type = MessageType.Success

            });
            return RedirectToAction("Index", "Home", new { area = "DataOperator"});
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await this.productService.PrepareProductModelForEditingDeletingAsync(id);

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

        [HttpPost]
        public async Task<IActionResult> Delete(int id, ProductBindingModel model)
        {

            if (!await this.productService.DeleteProductAsync(id))
            {
                this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
                {
                    Message = InfoMessages.UnableToDeleteProduct,
                    Type = MessageType.Danger

                });

                return RedirectToAction("Add", "Products", new { area = "dataOperator" });
            }

       
            this.TempData.Put(MessagesConstants.TempDataMessageKey, new MessageModel()
            {
                Message = SuccessMessages.DeleteProduct,
                Type = MessageType.Success

            });
            return RedirectToAction("Index", "Home", new { area = "DataOperator" });
        }
    }
}