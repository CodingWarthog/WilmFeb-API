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
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _friendService;

        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpGet("checkIfFriend/{friendLogin}")]
        public async Task<IActionResult> CheckIfFriendAsync([FromRoute] string friendLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isFriend = await _friendService.CheckIfFriendAsync(friendLogin);

            return Ok(isFriend);
        }


        [HttpGet("getAllUsers")]
        public async Task<IActionResult> SearchUserAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var friend = await _friendService.FindAllUsersAsync();

            if (friend == null)
            {
                return NotFound();
            }

            return Ok(friend);
        }

        // GET: api/Friend/5
        [HttpGet("findUserFriends")]
        public async Task<IActionResult> GetUserAllFriendAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var friend = await _friendService.FindUserFriendsAsync();

            if (friend == null)
            {
                return NotFound();
            }

            return Ok(friend);
        }


        // PUT: api/Friend/5
        [HttpPost("addFriend/{friendLogin}")]
        public async Task<IActionResult> AddFriendAsync([FromRoute] string friendLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // save 
                await _friendService.AddFriendAsync(friendLogin);
                return Ok();
            }
            catch (Various.AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}