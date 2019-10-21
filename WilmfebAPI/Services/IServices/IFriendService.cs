using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilmfebAPI.DTOModels;

namespace WilmfebAPI.Services.IServices
{
    public interface IFriendService
    {
        Task AddFriendAsync(string friendLogin);
        Task<List<FriendDTO>> FindUserFriendsAsync();
        Task<List<FriendDTO>> FindAllUsersAsync();
        Task<bool> CheckIfFriendAsync(string friendLogin);
    }
}
