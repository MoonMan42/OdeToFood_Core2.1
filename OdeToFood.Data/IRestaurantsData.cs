using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRestaurantsData
    {
        IEnumerable<Restaurant> GetAllRestaurants();
    }
}
