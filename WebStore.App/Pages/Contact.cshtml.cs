using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebStore.App.Pages
{
    public class ContactModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "contact us";
        }
    }
}
