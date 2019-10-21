using System;
using System.Collections.Generic;

namespace WilmfebAPI.Models
{
    public partial class Watched
    {
        public int IdWatched { get; set; }
        public int IdUser { get; set; }
        public int IdMovie { get; set; }
        public int Mark { get; set; }

        public Movie IdMovieNavigation { get; set; }
        public User IdUserNavigation { get; set; }
    }
}
