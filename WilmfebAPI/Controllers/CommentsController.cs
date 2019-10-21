using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WilmfebAPI.DTOModels;
using WilmfebAPI.Models;
using WilmfebAPI.Services.IServices;

namespace WilmfebAPI.Controllers
{

    /* dodac async do nazw metod
     * logike przeniesc do servicu
     * upiekszyc uzytkownikow
     */
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // PUT: api/Comments
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> PutCommentsAsync([FromBody] CommentRecievedDTO comm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _commentService.addCommentAsync(comm);
                return Ok();
            }
            catch (Various.AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            
        }

        [HttpGet("all/{id}")]
        public async  Task<List<CommentDTO>> GetAllCommentsAsync([FromRoute] int id)
        {
            return await _commentService.getAllCommentsAsync(id); 
        }
    }
}