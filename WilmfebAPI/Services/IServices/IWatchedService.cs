using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilmfebAPI.DTOModels;

namespace WilmfebAPI.Services.IServices
{
    public interface IWatchedService
    {
        Task addMarkToMovieAsync(WatchedRecieved watchedAdd);
        Task<List<WatchedMovieDTO>> GetLoggedUserWatchedMoviesAsync();
        Task<int> HowManyWatchedAsync(string userLogin);
    }
}
