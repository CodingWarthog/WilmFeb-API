using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilmfebAPI.DTOModels;
using WilmfebAPI.Models;
using WilmfebAPI.Repositories.IRepositories;
using WilmfebAPI.Services.IServices;
using WilmfebAPI.Various;

namespace WilmfebAPI.Services
{
    public class CommentService : ControllerBase, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly IUserGeter _userGeter;

        public CommentService(ICommentRepository commentRepository, IMapper mapper, IUserGeter userGeter)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _userGeter = userGeter;
        }

        public async Task addCommentAsync(CommentRecievedDTO comm)
        {
            Comments comment = _mapper.Map<Comments>(comm);
            comment.IdUser = _userGeter.GetUser();

            await _commentRepository.addCommentAsync(comment);
        }

        public async Task<List<CommentDTO>> getAllCommentsAsync(int id)
        {
            var commentsRep = await _commentRepository.getAllCommentsAsync(id);
            var comDto = _mapper.Map<List<CommentDTO>>(commentsRep);

            return comDto;
        }
    }
}
