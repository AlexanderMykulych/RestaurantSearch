using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entity
{
    public class Reviewe
    {
        public int Id { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewerMessage { get; set; }

        public virtual RestaurantInfo RestaurantInfo { get; set; }
        
    }
}
