using System;
using System.Collections.Generic;

namespace WilmfebAPI.Models
{
    public class CategoryToMovie
    {
        public int IdCategoryToMovie { get; set; }
        public int IdMovie { get; set; }
        public int IdCategory { get; set; }

        public Categories IdCategoryNavigation { get; set; }
        public Movie IdMovieNavigation { get; set; }
    }
}
