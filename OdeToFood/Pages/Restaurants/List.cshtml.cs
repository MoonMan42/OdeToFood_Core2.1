using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantsData restaurantsData;

        public IEnumerable<Restaurant> restaurant { get; set; }

        [BindProperty(SupportsGet = true)]
        public string searchTerm { get; set; }

        public ListModel(IRestaurantsData restaurantsData)
        {
            this.restaurantsData = restaurantsData;
        }

        public void OnGet()
        {
            restaurant = restaurantsData.GetRestaurantsByName(searchTerm);
        }
    }
}