using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilmfebAPI.Models;

namespace WilmfebAPI.Repositories.IRepositories
{
    public interface ICategoryToMovieRepository
    {
        Task<int> GetCategoriesNumberAsync();
        Task<List<CategoryToMovie>> GetCatToMovAsync(int movieId);
        Task<List<CategoryToMovie>> GetInfoForTwoCatAsync(int idFirstCat, int idSecondCat);
    }
}
