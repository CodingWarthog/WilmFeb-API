using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilmfebAPI.DTOModels;
using WilmfebAPI.Models;

namespace WilmfebAPI.Repositories.IRepositories
{
    public interface IWatchedRepository
    {
        Task<Watched> getMarkAsync(int movieId, int userId);
        Task updateMovieMarkAsync(Watched watched);
        Task addNewMovieMarkAsync(Watched watched);
        Task<List<Watched>> getLoggedUserWatchedMoviesAsync(int userId);
        Task<Watched> getUserMark(int movieId, int userId);
        Task<List<Watched>> getMovieMarks(int movieId);
        Task<List<Watched>> getFriendWatchedMovie(string userLogin);
    }
}
