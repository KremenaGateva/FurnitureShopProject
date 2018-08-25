namespace WebStore.App.Pages.Categories
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using WebStore.Common.Anonymous.ViewModels;
    using WebStore.Services.Anonymous.Interfaces;

    public class DetailsModel : PageModel
    {
        private readonly IAnonymousCategoriesService categoriesService;

        public DetailsModel(IAnonymousCategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [BindProperty]
        public CategoryIndexDetailsViewModel Category { get; set; }

        public async Task OnGet(int id)
        {
            this.Category = await this.categoriesService.GetCategoryByIdAsync(id);
        }
    }
}