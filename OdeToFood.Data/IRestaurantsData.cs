using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantsData
    {
        IEnumerable<Restaurant> GetAllRestaurants();
    }

    public class InMemoryRestaurantData : IRestaurantsData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>();

            restaurants = new List<Restaurant>()
            {
                new Restaurant{Name = "Scott's", Location="New England", Cuisine=CuisineType.Italian},
                new Restaurant{Name = "Marco's", Location="Atlanta", Cuisine= CuisineType.Mexican},
                new Restaurant{Name = "Raji's", Location="Bosie", Cuisine=CuisineType.Indian}
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
