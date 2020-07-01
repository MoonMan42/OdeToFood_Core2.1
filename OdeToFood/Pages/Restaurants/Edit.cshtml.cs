using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantsData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantsData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restaurantId)
        {
            if (restaurantId.HasValue)
            {
                restaurant = restaurantData.GetRestaurantsById(restaurantId.Value);

            }
            else
            {
                restaurant = new Restaurant();

            }


            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            return Page();
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

                return Page();
            }

            if (restaurant.Id > 0)
            {
                restaurantData.Update(restaurant);
                TempData["Message"] = "Restaurant Updated";
            }
            else
            {
                restaurantData.Add(restaurant);
                TempData["Message"] = "Restaurant Saved";
            }

            restaurantData.Commit();

            return RedirectToPage("./Details", new { restaurantId = restaurant.Id });
        }
    }
}