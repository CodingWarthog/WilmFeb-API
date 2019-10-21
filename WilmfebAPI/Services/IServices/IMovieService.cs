using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilmfebAPI.DTOModels;
using WilmfebAPI.Models;
using WilmfebAPI.Various;

namespace WilmfebAPI.Services.IServices
{
    public interface IMovieService
    {
        Task<MovieDetails> GetMovieAsync(int movieId);
        Task<float> GetMovieAverageMarkAsync(int movieId);
        Task<PagedList<MovieInfo>> GetAllMoviesAsync(UserParams userParams);
        Task<List<MovieInfo>> GetRecommendedMoviesAsync();
        Task<List<MovieInfo>> GetSearchedMoviesAsync(string searchStr);
        Task<List<MovieFriend>> LoadUserProfileAsync(string userLogin);
    }
}
