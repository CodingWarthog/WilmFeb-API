using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilmfebAPI.DTOModels;

namespace WilmfebAPI.Services.IServices
{
    public interface ICommentService
    {
        Task addCommentAsync(CommentRecievedDTO comm);
        Task<List<CommentDTO>> getAllCommentsAsync(int id);
    }
}
