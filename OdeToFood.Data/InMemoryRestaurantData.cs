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



        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.ToLower().StartsWith(name.ToLower())
                   orderby r.Name
                   select r;
        }

        public Restaurant GetRestaurantsById(int Id)
        {
            return restaurants.SingleOrDefault(r => r.Id == Id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);

            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }

        public int Commit()
        {
            return 0; // not for in-memory
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);

            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;

            return newRestaurant;
        }
    }
}
