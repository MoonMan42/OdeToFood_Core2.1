using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlRestarantsData : IRestaurantsData
    {
        private readonly OdeToFoodDbContext _context;
        public SqlRestarantsData(OdeToFoodDbContext db)
        {
            _context = db;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _context.Add(newRestaurant);
            return newRestaurant;
        }


        public Restaurant Delete(int Id)
        {
            var restaurant = GetRestaurantsById(Id);

            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public Restaurant GetRestaurantsById(int Id)
        {
            return _context.Restaurants.Find(Id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in _context.Restaurants
                        where string.IsNullOrEmpty(name) || r.Name.ToLower().StartsWith(name.ToLower())
                        orderby r.Name
                        select r;

            return query;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var entity = _context.Restaurants.Attach(restaurant);
            entity.State = EntityState.Modified;
            return restaurant;
        }
    }

}
