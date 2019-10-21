using AutoMapper;
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
    public class WatchedService : IWatchedService 
    {
        private readonly IWatchedRepository _watchedRepository;
        private readonly IMapper _mapper;
        private readonly IUserGeter _userGeter;

        public WatchedService(IWatchedRepository watchedRepository, IMapper mapper, IUserGeter userGeter)
        {
            _watchedRepository = watchedRepository;
            _mapper = mapper;
            _userGeter = userGeter;
        }

        public async Task<List<WatchedMovieDTO>> GetLoggedUserWatchedMoviesAsync()
        {
            int userId = _userGeter.GetUser();
            var watchedRep = await _watchedRepository.getLoggedUserWatchedMoviesAsync(userId);
            var watchedDTO = _mapper.Map<List<WatchedMovieDTO>>(watchedRep);

            return watchedDTO;
        }

        
        public async Task<int> HowManyWatchedAsync(string userLogin)
        {
            var watched = await _watchedRepository.getFriendWatchedMovie(userLogin);
            int number = watched.Count;

            return number;
        }

        public async Task addMarkToMovieAsync(WatchedRecieved watchedRecieved)
        {
            int userId = _userGeter.GetUser();
            var watched = await _watchedRepository.getMarkAsync(watchedRecieved.IdMovie, userId); 
            var mark = _mapper.Map<Watched>(watchedRecieved);
            mark.IdUser = userId;

            if (watched == null)
            {
                //jesli uzytkownik pierwszy raz ocenia
                await _watchedRepository.addNewMovieMarkAsync(mark);
            }
            else
            {
                //jesli uzytkownk edytuje ocene
                await _watchedRepository.updateMovieMarkAsync(mark);
            }
        }
    }
}
