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
    public class QueueRepository : IQueueRepository
    {
        private readonly WilmfebDBContext _dbContext;

        public QueueRepository(WilmfebDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Queue>> getAllMoviesInUserQueueAsync(int userId)
        {
            var moviesInQueue = await _dbContext.Queue
                                    .Include(m=>m.IdMovieNavigation)
                                    .Where(q => q.IdUser == userId)
                                    .ToListAsync();
            return moviesInQueue;
        }

        public async Task addMovieToQueueAsync(Queue movieToQueue)
        {
            await _dbContext.Queue.AddAsync(movieToQueue);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Queue> checkIfMovieIsInUserQueueAsync(int movieId, int userId)
        {
            return await _dbContext.Queue
                .Where(q => q.IdMovie == movieId && q.IdUser == userId)
                .SingleOrDefaultAsync();
        }
    }
}
