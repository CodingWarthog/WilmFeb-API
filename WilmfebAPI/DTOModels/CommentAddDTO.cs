using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilmfebAPI.DTOModels
{
    public class CommentAddDTO
    {
        public int IdUser { get; set; }
        public int IdMovie { get; set; }
        public string Comment { get; set; }
    }
}
