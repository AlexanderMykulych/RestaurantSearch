﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entity
{
    public class RestaurantInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public string Description { get; set; }

        public virtual List<Reviewe> Reviewes { get; set; }
    }
}