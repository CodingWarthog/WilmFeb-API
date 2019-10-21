using System;
using System.Collections.Generic;

namespace WilmfebAPI.Models
{
    public class Categories
    {
        public Categories()
        {
            CategoryToMovie = new HashSet<CategoryToMovie>();
        }

        public int IdCategory { get; set; }
        public string Category { get; set; }

        public ICollection<CategoryToMovie> CategoryToMovie { get; set; }
    }
}
