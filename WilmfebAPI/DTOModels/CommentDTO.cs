using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilmfebAPI.DTOModels
{
    public class CommentDTO
    {
        public int idUser { get; set; }
        public string user { get; set; }
        public string comment { get; set; }
    }
}
