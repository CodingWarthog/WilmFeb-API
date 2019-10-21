using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WilmfebAPI.Models;
using WilmfebAPI.Services.IServices;

namespace WilmfebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {

        private readonly IQueueService _queueService;

        public QueueController(IQueueService queueService)
        {
            _queueService = queueService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllMoviesInUserQueueAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movieInQueue = await _queueService.GetAllMoviesInUserQueueAsync();

            return Ok(movieInQueue);
        }

        [HttpGet("check/{movieId}")]
        public async Task<IActionResult> CheckIfInQueueAsync([FromRoute] int movieId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movieInQueue = await _queueService.CheckIfMovieIsInUserQueueAsync(movieId);

            return Ok(movieInQueue);
        }


        // POST: api/Queue
        [HttpPost("{movieId}")]
        public async Task<IActionResult> PostQueueAsync([FromRoute] int movieId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // save 
                await _queueService.addMovieToQueueAsync(movieId);
                return Ok();
            }
            catch (Various.AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }
    }

}