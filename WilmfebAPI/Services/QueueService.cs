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
    public class QueueService : IQueueService
    {
        private readonly IQueueRepository _queueRepository;
        private readonly IMapper _mapper;
        private readonly IUserGeter _userGeter;
        
        public QueueService(IQueueRepository queueRepository, IMapper mapper, IUserGeter userGeter)
        {
            _queueRepository = queueRepository;
            _mapper = mapper;
            _userGeter = userGeter;
        }

        public async Task<List<MovieFromQueue>> GetAllMoviesInUserQueueAsync()
        {
            int userId = _userGeter.GetUser();
            var queueRep =  await _queueRepository.getAllMoviesInUserQueueAsync(userId);
            var queueDTO = _mapper.Map<List<MovieFromQueue>>(queueRep);

            return queueDTO;
        }

        public async Task<bool> CheckIfMovieIsInUserQueueAsync(int movieId)
        {
            int userId = _userGeter.GetUser();
            var queue = await _queueRepository.checkIfMovieIsInUserQueueAsync(movieId, userId);
            bool flag = true;

            if (queue == null)
            {
                flag = false;
            }

            return flag;
        }

        public async Task addMovieToQueueAsync(int movieId)
        {
            int userId = _userGeter.GetUser();
            QueueAddMovie queueAddMovie = new QueueAddMovie(userId, movieId);
            var movieToQueue = _mapper.Map<Queue>(queueAddMovie);

            await _queueRepository.addMovieToQueueAsync(movieToQueue);
        }

    }
}
