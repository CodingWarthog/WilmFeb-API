using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilmfebAPI.DTOModels;
using WilmfebAPI.Models;

namespace WilmfebAPI.Repositories.IRepositories
{
    public interface ICommentRepository
    {
        Task addCommentAsync(Comments comment);
        //Task<List<CommentDTO>> getAllCommentsAsync(int id);
        Task<List<Comments>> getAllCommentsAsync(int id);
    }
}
