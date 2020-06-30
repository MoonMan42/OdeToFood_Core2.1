using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantsData restaurantsData;

        public ListModel(IRestaurantsData restaurantsData)
        {
            this.restaurantsData = restaurantsData;
        }

        public void OnGet()
        {
        }
    }
}