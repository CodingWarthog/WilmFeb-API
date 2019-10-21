using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilmfebAPI.DTOModels;
using WilmfebAPI.Models;
using WilmfebAPI.Repositories.IRepositories;

namespace WilmfebAPI.Repositories
{

    public class FriendRepository : IFriendRepository
    {
        private readonly WilmfebDBContext _dbContext;

        public FriendRepository(WilmfebDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<List<Friend>> findUserFriendsAsync(int userId)
        {
            return await _dbContext.Friend
                                .Include(u1 => u1.IdUser1Navigation)
                                .Include(u2 => u2.IdUser2Navigation)
                                .Where(u => u.IdUser2Navigation.IdUser == userId)
                                .ToListAsync();
        }
        public async Task addFriendAsync(Friend friend)
        {
            await _dbContext.Friend.AddAsync(friend);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<User>> findAllUsersAsync(int userId)
        {
            return await _dbContext.User.Where(u => u.IdUser != userId).ToListAsync();
        }

        public async Task<Friend> checkIfFriendAsync(int friendId, int userId)
        {
            var friend = await _dbContext.Friend
                              .Where(f => (f.IdUser1 == friendId && f.IdUser2 == userId))
                              .FirstOrDefaultAsync();
            return friend;
        }
    }
}
