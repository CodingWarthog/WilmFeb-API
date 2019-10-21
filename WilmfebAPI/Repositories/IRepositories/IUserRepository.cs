using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilmfebAPI.Models;

namespace WilmfebAPI.Repositories.IRepositories
{
    public interface IUserRepository
    {
        User GetByLogin(string login);
        List<User> GetAllUsersLogins();
        User GetById(int id);
        void CanICreateUser(User user, string password);
        void AddNewUser(User user);
    }
}
