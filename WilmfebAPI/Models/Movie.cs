using System;
using System.Collections.Generic;

namespace WilmfebAPI.Models
{
    public class Movie
    {
        public Movie()
        {
            CategoryToMovies = new HashSet<CategoryToMovie>();
            Commentss = new HashSet<Comments>();
            Queues = new HashSet<Queue>();
            Watcheds = new HashSet<Watched>();
        }

        public int IdMovie { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public int? Year { get; set; }
        public string Image { get; set; }

        public string Trailer { get; set; }

        public ICollection<CategoryToMovie> CategoryToMovies { get; set; }
        public ICollection<Comments> Commentss { get; set; }
        public ICollection<Queue> Queues { get; set; }
        public ICollection<Watched> Watcheds { get; set; }
    }
}
