using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilmfebAPI.DTOModels;
using WilmfebAPI.Models;
using WilmfebAPI.Various;

namespace WilmfebAPI.Repositories.IRepositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> getMovies();
        Task<Movie> getMovieAsync(int movieId);
        Task<List<CategoryToMovie>> getMoviesCategories(int movieId);
        Task<List<Movie>> GetMoviesAsync();
        Task<List<Movie>> getSearchedMoviesAsync(string searchStr);
    }
}
