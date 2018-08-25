namespace WebStore.App.Pages.Products
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using WebStore.Common.Anonymous.ViewModels;
    using WebStore.Services.Anonymous.Interfaces;

    public class DetailsModel : PageModel
    {
        private readonly IAnonymousProductsService productsService;

        public DetailsModel(IAnonymousProductsService productsService)
        {
            this.productsService = productsService;
        }

        [BindProperty]
        public ProductIndexDetailsViewModel Product { get; set; }

        public async Task OnGet(int id)
        {
            this.Product = await this.productsService.GetProductById(id);
        }
    }
}