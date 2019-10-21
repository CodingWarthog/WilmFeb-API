using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilmfebAPI.DTOModels;
using WilmfebAPI.Models;

namespace WilmfebAPI.Services.IServices
{
    public interface IQueueService
    {
        Task addMovieToQueueAsync(int movieId);
        Task<bool> CheckIfMovieIsInUserQueueAsync(int movieId);
        Task<List<MovieFromQueue>> GetAllMoviesInUserQueueAsync();
    }
}
