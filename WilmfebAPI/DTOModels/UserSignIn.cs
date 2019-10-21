using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilmfebAPI.DTOModels
{
    public class UserSignIn
    {
       // public int IdUser { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
