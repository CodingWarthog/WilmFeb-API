using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilmfebAPI.DTOModels
{
    public class MovieDetails
    {
        public int IdMovie { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public int? Year { get; set; }
        public string Image { get; set; }
        public string Trailer { get; set; }
        public int UserMark { get; set; }
        public float GlobalMark { get; set; }

        public ICollection<CategoryDTO> MovieCategories { get; set; }
        public ICollection<CommentDTO> MovieComments { get; set; }
    }
}
