using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilmfebAPI.DTOModels
{
    public class MovieFriend
    {
        public int IdMovie { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public int? Year { get; set; }
        public string Image { get; set; }
        public int Mark { get; set; }
        public ICollection<CategoryDTO> MovieCategories { get; set; }

    }
}
