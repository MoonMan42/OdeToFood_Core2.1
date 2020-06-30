using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        private readonly IRestaurantsData restaurantsData;
        public Restaurant restaurant { get; set; }

        public DetailsModel(IRestaurantsData restaurantsData)
        {
            this.restaurantsData = restaurantsData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            restaurant = restaurantsData.GetRestaurantsById(restaurantId);

            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();

        }
    }
}