namespace WebStore.App.Pages
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using WebStore.Common.Anonymous.ViewModels;
    using WebStore.Models;
    using WebStore.Services.Anonymous.Interfaces;
    using WebStore.Utilities.Constants;

    public class IndexModel : PageModel
    {
        private readonly IAnonymousProductsService productsService;
        private readonly IAnonymousCategoriesService categoriesService;
        private readonly UserManager<User> userManager;

        public IndexModel(IAnonymousProductsService productsService,
            IAnonymousCategoriesService categoriesService,
            UserManager<User> userManager)
        {
            this.productsService = productsService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
        }

        [BindProperty]
        public IEnumerable<ProductIndexConciseViewModel> ProductsModels { get; set; }

        [BindProperty]
        public IEnumerable<CategoryIndexConciseViewModel> CategoriesModels { get; set; }


        public async Task<IActionResult> OnGet()
        {
            this.ProductsModels = await this.productsService.GetLastTwentyProductsAsync();
            this.CategoriesModels = await this.categoriesService.GetAllCategoriesAlphabeticallyAsync();

            var user = await this.userManager.GetUserAsync(this.User);
            if (user != null)
            {
                var roles = await this.userManager.GetRolesAsync(user);

                if (roles.Contains(RolesConstants.RoleNames.DataOperator))
                {
                    return RedirectToAction("Index", "Home", new { area = AreasConstants.AreaNames.DataOperator });
                }
                else if (roles.Contains(RolesConstants.RoleNames.Administrator))
                {
                    return RedirectToAction("Index", "Home", new { area = AreasConstants.AreaNames.Administrator });
                }
            }
            return Page();
        }
    }
}
