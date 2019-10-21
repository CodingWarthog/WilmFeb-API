using System;
using System.Collections.Generic;

namespace WilmfebAPI.Models
{
    public partial class Comments
    {
        public int IdComments { get; set; }
        public int IdUser { get; set; }
        public int IdMovie { get; set; }
        public string Comment { get; set; }

        public Movie IdMovieNavigation { get; set; }
        public User IdUserNavigation { get; set; }
    }
}
