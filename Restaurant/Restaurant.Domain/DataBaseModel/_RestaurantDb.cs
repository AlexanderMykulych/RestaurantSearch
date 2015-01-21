using Restaurant.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.DataBaseModel
{
    public class _RestaurantDb : DbContext, IRestaurantDb
    {
        public _RestaurantDb() : base("DefaultConnection")
        {

        }
        public DbSet<RestaurantInfo> Restaurants {get; set;}

        public DbSet<Reviewe> Reviewes { get; set; }


        IQueryable<RestaurantInfo> IRestaurantDb.Restaurants
        {
            get 
            {
                return Restaurants;
            }
        }

        IQueryable<Reviewe> IRestaurantDb.Reviewes
        {
            get
            {
                return Reviewes;
            }
        }

        public void Save()
        {
            SaveChanges();
        }

        public void AddRestaurants(RestaurantInfo restaurant)
        {
            Restaurants.Add(restaurant);
        }

        public void AddReview(Reviewe review)
        {
            Reviewes.Add(review);
        }


        public void Delete(int itemId)
        {
            Restaurants.Remove(Restaurants.Where(x => x.Id == itemId).FirstOrDefault());
        }
    }
}
