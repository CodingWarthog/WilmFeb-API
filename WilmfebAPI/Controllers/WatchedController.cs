using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WilmfebAPI.DTOModels;
using WilmfebAPI.Models;
using WilmfebAPI.Services.IServices;

namespace WilmfebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WatchedController : ControllerBase
    {
        private readonly IWatchedService _watchedService;

        public WatchedController(IWatchedService watchedService)
        {
            _watchedService = watchedService;
        }

        // GET: api/Watched/5
        [HttpGet("myWatchedMovies")]
        public async Task<IActionResult> GetLoggedUserWatchedMoviesAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var watchedMovies = await _watchedService.GetLoggedUserWatchedMoviesAsync();

            return Ok(watchedMovies);
        }
        

        [HttpGet("howManyWatched/{userLogin}")]
        public async Task<IActionResult> HowManyWatchedAsync([FromRoute]  string userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var watchedNumber = await _watchedService.HowManyWatchedAsync(userLogin);

            return Ok(watchedNumber);
        }

        // PUT: api/Watched
        [HttpPut]
        public async Task<IActionResult> PutWatchedAsync([FromBody]  WatchedRecieved watchAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _watchedService.addMarkToMovieAsync(watchAdd);
                return Ok();
            }
            catch (Various.AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

    }
}