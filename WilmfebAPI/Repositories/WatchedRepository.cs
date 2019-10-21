using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilmfebAPI.DTOModels;
using WilmfebAPI.Models;
using WilmfebAPI.Repositories.IRepositories;

namespace WilmfebAPI.Repositories
{
    public class WatchedRepository : IWatchedRepository
    {
        private readonly WilmfebDBContext _dbContext;

        public WatchedRepository(WilmfebDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Watched> getMarkAsync(int movieId, int userId)
        {
            var watched = await _dbContext.Watched
                   .Where(w => w.IdMovie == movieId && w.IdUser == userId)
                   .FirstOrDefaultAsync();

            return watched;
        }

        public async Task updateMovieMarkAsync(Watched watched)
        {
            var watchedAdd = await _dbContext.Watched
                     .Where(w => w.IdMovie == watched.IdMovie && w.IdUser == watched.IdUser)
                     .FirstOrDefaultAsync();

            watchedAdd.Mark = watched.Mark;

            _dbContext.Entry(watchedAdd).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task addNewMovieMarkAsync(Watched watched)
        {
            await _dbContext.Watched.AddAsync(watched);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Watched>> getLoggedUserWatchedMoviesAsync(int userId)
        {
            var moviesInQueue = await _dbContext.Watched
                                    .Include(m => m.IdMovieNavigation)
                                    .Where(q => q.IdUser == userId)
                                    .ToListAsync();
            return moviesInQueue;
        }

        public async Task<Watched> getUserMark(int movieId, int userId)
        {
            var userMarkDB = _dbContext.Watched
                            .Where(w => w.IdMovie == movieId && w.IdUser == userId)
                            .FirstOrDefault();
            return userMarkDB;
        }

        public async Task<List<Watched>> getMovieMarks(int movieId)
        {
            return await _dbContext.Watched
                        .Where(w => w.IdMovie == movieId)
                        .ToListAsync();
        }

        public async Task<List<Watched>> getFriendWatchedMovie(string userLogin)
        {
            return await _dbContext.Watched
                          .Include(mn => mn.IdMovieNavigation)
                          .Include(un => un.IdUserNavigation)
                          .Where(un => un.IdUserNavigation.Login == userLogin)
                          .ToListAsync();
        }
        
    }
}
