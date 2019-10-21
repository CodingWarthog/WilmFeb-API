using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WilmfebAPI.Services.IServices;
using WilmfebAPI.Various;

namespace WilmfebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/Movie/averageMark/5
        [HttpGet("averageMark/{movieId}")]
        public async Task<IActionResult> GetMovieAverageMark([FromRoute] int movieId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movie = await _movieService.GetMovieAverageMarkAsync(movieId);

            return Ok(movie);
        }

        [HttpGet("userProfile/{userLogin}")]
        public async Task<IActionResult> LoadUserProfileAsync([FromRoute] string userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movie = await _movieService.LoadUserProfileAsync(userLogin);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }



        // GET: api/Movie/5    
        [HttpGet("{movieId}")]
        public async Task<IActionResult> GetMovieAsync([FromRoute] int movieId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movie = await _movieService.GetMovieAsync(movieId);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpGet("recommended")]
        public async Task<IActionResult> GetRecommendedMoviesAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //int userId = int.Parse(User.Identity.Name);

            var movie = await _movieService.GetRecommendedMoviesAsync();
            //Response.AddPagination(movie.CurrentPage, movie.PageSize, movie.TotalCount, movie.TotalPages);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [Authorize]
        [HttpGet("all")]
        public async Task<IActionResult> GetMoviesAsync([FromQuery] UserParams userParams)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movie = await _movieService.GetAllMoviesAsync(userParams);

            Response.AddPagination(movie.CurrentPage, movie.PageSize, movie.TotalCount, movie.TotalPages);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpGet("search/{searchStr}")]
        public async Task<IActionResult> getSearchedMoviesAsync([FromRoute] string searchStr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movie = await _movieService.GetSearchedMoviesAsync(searchStr);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

    }
}