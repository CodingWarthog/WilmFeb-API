using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilmfebAPI.DTOModels;
using WilmfebAPI.Models;
using WilmfebAPI.Repositories.IRepositories;
using WilmfebAPI.Services.IServices;
using WilmfebAPI.Various;

namespace WilmfebAPI.Services
{
    public class FriendService : ControllerBase, IFriendService
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserGeter _userGeter;
        private readonly IMapper _mapper;

        public FriendService(IFriendRepository friendRepository,
                            IMapper mapper,
                            IUserRepository userRepository,
                            IUserGeter userGeter)
        {
            _friendRepository = friendRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _userGeter = userGeter;
        }

        public async Task<List<FriendDTO>> FindUserFriendsAsync()
        {
            int userId = _userGeter.GetUser();
            var userRep = await _friendRepository.findUserFriendsAsync(userId);
            var userMap = _mapper.Map<List<FriendDTO>>(userRep);

            return userMap;
        }

        
        public async Task<List<FriendDTO>> FindAllUsersAsync()
        {
           int userId = _userGeter.GetUser();
           var userRep = await _friendRepository.findAllUsersAsync(userId);
           var userMap = _mapper.Map<List<FriendDTO>>(userRep);

           return userMap;
        }

       public async Task AddFriendAsync(string friendLogin)
       {
           int userId = _userGeter.GetUser();
           var friend = _userRepository.GetByLogin(friendLogin);

           if(friend.IdUser != userId)
           {
                Friend addFriend = new Friend();
                addFriend.IdUser1 = friend.IdUser;
                addFriend.IdUser2 = userId;
                await _friendRepository.addFriendAsync(addFriend);
           }
       }

       public async Task<bool> CheckIfFriendAsync(string friendLogin)
       {
           int userId = _userGeter.GetUser();
           var friendInfo = _userRepository.GetByLogin(friendLogin);

           if (friendInfo.IdUser != userId)
           {
               var checkIfFriend = await _friendRepository.checkIfFriendAsync(friendInfo.IdUser, userId);
               if(checkIfFriend != null)
               {
                   return true;
               }
           }
           return false;
       }
   }
}
