using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilmfebAPI.Models;
using WilmfebAPI.Repositories.IRepositories;

namespace WilmfebAPI.Repositories
{
    public class CategoryToMovieRepository: ICategoryToMovieRepository
    {
        private readonly WilmfebDBContext _dbContext;

        public CategoryToMovieRepository(WilmfebDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<int> GetCategoriesNumberAsync()
        {
            return await _dbContext.Categories.Select(c => c.Category).Distinct().CountAsync() + 1;
        }

        public async Task<List<CategoryToMovie>> GetCatToMovAsync(int movieId)
        {
            return await _dbContext.CategoryToMovie
                   .Where(ctm => ctm.IdMovie == movieId)
                   .ToListAsync();
        }
        
        public async Task<List<CategoryToMovie>> GetInfoForTwoCatAsync(int idFirstCat, int idSecondCat)
        {
           return await _dbContext.CategoryToMovie
                  .Include(cat=>cat.IdMovieNavigation)
                  .Where(w => w.IdCategory == idFirstCat || w.IdCategory == idSecondCat)
                  .ToListAsync();
        }
    }
}
