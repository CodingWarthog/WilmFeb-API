using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilmfebAPI.DTOModels;
using WilmfebAPI.Models;

namespace WilmfebAPI.Repositories.IRepositories
{
    public interface IFriendRepository
    {
        Task addFriendAsync(Friend friend);
        Task<List<Friend>> findUserFriendsAsync(int userId);
        Task<List<User>> findAllUsersAsync(int userId);
        Task<Friend> checkIfFriendAsync(int friendId, int userId);
    }
}
