using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilmfebAPI.DTOModels;
using WilmfebAPI.Models;
using WilmfebAPI.Repositories.IRepositories;
using WilmfebAPI.Various;

namespace WilmfebAPI.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly WilmfebDBContext _dbContext;

        public MovieRepository(WilmfebDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Movie> getMovieAsync(int movieId)
        {
            var movie = await _dbContext.Movie
                                    .Where(m => m.IdMovie == movieId)
                                    .FirstOrDefaultAsync();
            return movie;
        }

        public async Task<List<CategoryToMovie>> getMoviesCategories(int movieId)
        {
            var catToMov = await _dbContext.CategoryToMovie
                                    .Include(c=>c.IdCategoryNavigation)
                                    .Where(ctm => ctm.IdMovie == movieId)
                                    .ToListAsync();
            return catToMov;
        }
       
        public async Task<List<Movie>> getSearchedMoviesAsync(string searchStr)
        {
            var moviesToReturn = await _dbContext.Movie
                            .Where(movie => movie.Title.Contains(searchStr))
                            .ToListAsync();
            return moviesToReturn;
        }

        public async Task<List<Movie>> GetMoviesAsync()
        {
            return await _dbContext.Movie.ToListAsync();
        }

        public Task<IEnumerable<Movie>> getMovies()
        {
            throw new NotImplementedException();
        }
    }
}
