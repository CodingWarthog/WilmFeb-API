using System;
using System.Collections.Generic;

namespace WilmfebAPI.Models
{
    public partial class Friend
    {
        public int IdFriend { get; set; }
        public int IdUser1 { get; set; } //dodany znajomy
        public int IdUser2 { get; set; } //ten co dodal

        public User IdUser1Navigation { get; set; }
        public User IdUser2Navigation { get; set; }
    }
}
