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
    public class MovieService : ControllerBase, IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        private readonly IUserGeter _userGeter;
        private readonly ICommentRepository _commentRepository;
        private readonly IWatchedRepository _watchedRepository;
        private readonly ICategoryToMovieRepository _catToMov;

        public MovieService(IMovieRepository movieRepository, 
                            IMapper mapper, 
                            IUserGeter userGeter, 
                            ICommentRepository commentRepository,
                            IWatchedRepository watchedRepository,
                            ICategoryToMovieRepository catToMov)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _userGeter = userGeter;
            _commentRepository = commentRepository;
            _watchedRepository = watchedRepository;
            _catToMov = catToMov;
        }

        public async Task<List<MovieInfo>> GetRecommendedMoviesAsync()
        {
            int userId = _userGeter.GetUser();
            var watched = await _watchedRepository.getLoggedUserWatchedMoviesAsync(userId);

            List<MovieInfo> movies = new List<MovieInfo>();

            if (watched.Count > 0)
            {
                int categories = await _catToMov.GetCategoriesNumberAsync();

                int[] counter = new int[categories + 1];
                for (int i = 0; i < counter.Length - 1; i++)
                {
                    counter[i] = 0;
                }

                for (int i = 0; i < watched.Count; i++)
                {
                    //kategorie z obejrzanego filmu
                    var categoriesToMovie = await _catToMov.GetCatToMovAsync(watched[i].IdMovie);
                    //int categoriesToMovieNumber = categoriesToMovie.Count();

                    for (int j = 0; j < categoriesToMovie.Count(); j++)
                    {
                        //-1 bo kategorie w bazie zaczynaja sie od id=1 a counter od 0
                        counter[categoriesToMovie[j].IdCategory]++;// = counter[categoriesToMovie[j].IdCategory] + 1;
                    }
                }

                int first = 0;
                int second = 0;
                int idFirstCat = 0;
                int idSecondCat = 0;

                for (int i = 0; i < categories; i++)
                {
                    if (first < counter[i])
                    {
                        second = first;
                        first = counter[i];
                        idSecondCat = idFirstCat;
                        idFirstCat = i;
                    }
                    else if (second < counter[i])
                    {
                        second = counter[i];
                        idSecondCat = i;
                    }
                }

                var catToMov = await _catToMov.GetInfoForTwoCatAsync(idFirstCat, idSecondCat);

                var movieDetails = _mapper.Map<List<MovieInfo>>(catToMov);

                for (int i = 0; i < movieDetails.Count; i++)
                {
                    bool flag = true;

                    if (movies.Count > 0)
                    {
                        for (int x = 0; x < movies.Count; x++)
                        {
                            if (movieDetails[i].IdMovie == movies[x].IdMovie)
                            {
                                flag = false;
                                break;
                            }
                        }
                    }

                    for (int j = 0; j < watched.Count; j++)
                    {
                        if (movieDetails[i].IdMovie == watched[j].IdMovie)
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        int checMovieId = movieDetails[i].IdMovie;
                        var movieCategories = await _movieRepository.getMoviesCategories(movieDetails[i].IdMovie);
                        var cate  = _mapper.Map<List<CategoryDTO>>(movieCategories);
                        movieDetails[i].MovieCategories = cate;
                        movies.Add(movieDetails[i]);
                    }
                }
            }

            return movies;
        }

        public async Task<MovieDetails> GetMovieAsync(int movieId)
        {
            int userId = _userGeter.GetUser();
            var movieRep = await _movieRepository.getMovieAsync(movieId);
            var movieDetails = _mapper.Map<MovieDetails>(movieRep);
            var movieCategories = await _movieRepository.getMoviesCategories(movieId);
            var categories = _mapper.Map<List<CategoryDTO>>(movieCategories);
            movieDetails.MovieCategories = categories;
            var comments = await _commentRepository.getAllCommentsAsync(movieId);
            var mappedComments = _mapper.Map<List<CommentDTO>>(comments);
            movieDetails.MovieComments = mappedComments;
            var watched = await _watchedRepository.getUserMark(movieId, userId);

            if(watched == null)
            {
                movieDetails.UserMark = 0;
            }
            else
            {
                movieDetails.UserMark = watched.Mark;
            }

            movieDetails.GlobalMark = await GetMovieAverageMarkAsync(movieId);

            return movieDetails;
        }

        
        public async Task<List<MovieInfo>> GetSearchedMoviesAsync(string searchStr)
        {
            var movies = await _movieRepository.getSearchedMoviesAsync(searchStr);
            var movieInfo = await GetCategoriesForMovies(movies);

            return movieInfo;
        }

        public async Task<List<MovieInfo>> GetCategoriesForMovies(List<Movie> list)
        {
            var movieInfo = _mapper.Map<List<MovieInfo>>(list);

            for (int i = 0; i < movieInfo.Count; i++)
            {
                var movieCategories = await _movieRepository.getMoviesCategories(movieInfo[i].IdMovie);
                movieInfo[i].MovieCategories = _mapper.Map<List<CategoryDTO>>(movieCategories);
            }
            return movieInfo;
        }

        public async Task<List<MovieInfo>> GetCategoriesForMovies(List<Watched> list)
        {
            var movieInfo = _mapper.Map<List<MovieInfo>>(list);

            for (int i = 0; i < movieInfo.Count; i++)
            {
                var movieCategories = await _movieRepository.getMoviesCategories(movieInfo[i].IdMovie);
                movieInfo[i].MovieCategories = _mapper.Map<List<CategoryDTO>>(movieCategories);
            }
            return movieInfo;
        }

        public async Task<float> GetMovieAverageMarkAsync(int movieId)
        {
            var movieMarks = await _watchedRepository.getMovieMarks(movieId);

            int sum = 0;
            float av = 0;

            if (movieMarks.Count != 0)
            {
                for (int i = 0; i < movieMarks.Count; i++)
                {
                    sum = sum + movieMarks[i].Mark;
                }
                av = (float)sum / movieMarks.Count;
            }
            return av;
        }

        public async Task<PagedList<MovieInfo>> GetAllMoviesAsync(UserParams userParams)
        {
            var movies = await _movieRepository.GetMoviesAsync();
            var movieToReturn = await GetCategoriesForMovies(movies);

            return await PagedList<MovieInfo>.CreateAsync(movieToReturn, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<List<MovieFriend>> LoadUserProfileAsync(string userLogin)
        {
            var watchedByFriend = await _watchedRepository.getFriendWatchedMovie(userLogin);
            var watchedByFriendInfo = _mapper.Map<List<MovieFriend>>(watchedByFriend);

            for (int i = 0; i < watchedByFriendInfo.Count; i++)
            {
                var movieCategories = await _movieRepository.getMoviesCategories(watchedByFriendInfo[i].IdMovie);
                watchedByFriendInfo[i].MovieCategories = _mapper.Map<List<CategoryDTO>>(movieCategories);
            }

            return watchedByFriendInfo;
        }
    }
}
