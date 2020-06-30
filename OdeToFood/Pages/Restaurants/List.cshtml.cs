using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public string message { get; set; }

        public void OnGet()
        {
            message = "Hello World!";
        }
    }
}