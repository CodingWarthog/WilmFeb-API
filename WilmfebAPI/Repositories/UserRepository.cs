using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WilmfebAPI.Models;
using WilmfebAPI.Repositories.IRepositories;
using WilmfebAPI.Various;
using System.Threading.Tasks;

namespace WilmfebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WilmfebDBContext _dbContext;

        public UserRepository(WilmfebDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetByLogin(string login)
        {
            return  _dbContext.User
                .Where(user => user.Login == login)
                .FirstOrDefault();
        }

        public List<User> GetAllUsersLogins()
        {
            return _dbContext.User
                    .OrderBy(user => user.IdUser)
                    .ToList();
        }

        public User GetById(int id)
        {
            return _dbContext.User.Find(id);
        }

        public void CanICreateUser(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_dbContext.User.Any(x => x.Login == user.Login))
                throw new AppException("Login \"" + user.Login + "\" is already taken");
        }

        public void AddNewUser(User user)
        {
            _dbContext.User.Add(user);
            _dbContext.SaveChanges();
        }
    }
}
