using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilmfebAPI.DTOModels;
using WilmfebAPI.Models;

namespace WilmfebAPI.Repositories.IRepositories
{
    public interface IQueueRepository
    {
        Task addMovieToQueueAsync(Queue queue);
        Task<Queue> checkIfMovieIsInUserQueueAsync(int movieId, int userId);
        Task<List<Queue>> getAllMoviesInUserQueueAsync(int userId);
    }
}
