using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantsData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>();

            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 0,  Name = "Scott's", Location="New England", Cuisine=CuisineType.Italian},
                new Restaurant{Id = 1, Name = "Marco's", Location="Atlanta", Cuisine= CuisineType.Mexican},
                new Restaurant{Id = 2, Name = "Raji's", Location="Bosie", Cuisine=CuisineType.Indian}
            };
        }


        public IEnumerable<Restaurant> GetAllRestaurants()
        {


            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
