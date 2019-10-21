using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilmfebAPI.DTOModels
{
    public class QueueAddMovie
    {
        public int IdUser { get; set; }
        public int IdMovie { get; set; }

        public QueueAddMovie(int userId, int movieId)
        {
            IdUser = userId;
            IdMovie = movieId;
        }
    }
}
