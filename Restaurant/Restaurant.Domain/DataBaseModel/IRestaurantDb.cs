using Restaurant.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.DataBaseModel
{
    public interface IRestaurantDb
    {
        IQueryable<RestaurantInfo> Restaurants { get;}

        IQueryable<Reviewe> Reviewes { get; }

        void Save();

        void AddRestaurants(RestaurantInfo restaurant);
        void AddReview(Reviewe review);

        void Delete(int itemId);
    }
}
