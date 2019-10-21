using System;
using System.Collections.Generic;

namespace WilmfebAPI.Models
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comments>();
            FriendIdUser1Navigation = new HashSet<Friend>();
            FriendIdUser2Navigation = new HashSet<Friend>();
            Queue = new HashSet<Queue>();
            Watched = new HashSet<Watched>();
        }

        public int IdUser { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public ICollection<Comments> Comments { get; set; }
        public ICollection<Friend> FriendIdUser1Navigation { get; set; }
        public ICollection<Friend> FriendIdUser2Navigation { get; set; }
        public ICollection<Queue> Queue { get; set; }
        public ICollection<Watched> Watched { get; set; }
    }
}
