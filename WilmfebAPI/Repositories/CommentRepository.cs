using Microsoft.AspNetCore.Mvc;
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
    public class CommentRepository : ICommentRepository
    {
        private readonly WilmfebDBContext _dbContext;

        public CommentRepository(WilmfebDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task addCommentAsync(Comments comment)
        {
           await  _dbContext.Comments.AddAsync(comment);
           await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Comments>> getAllCommentsAsync(int id)
        {
            return await _dbContext.Comments
                        .Include(u=>u.IdUserNavigation)
                        .Where(comm => comm.IdMovie == id).ToListAsync();
        }
    }
}
