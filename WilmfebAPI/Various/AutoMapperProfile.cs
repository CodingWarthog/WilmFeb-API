using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WilmfebAPI.Models;
using WilmfebAPI.DTOModels;

namespace WilmfebAPI.Various
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //         z        do       i na odwrót      
            CreateMap<User, UserSignIn>().ReverseMap();

            CreateMap<Movie, MovieInfo>().ReverseMap();

            CreateMap<Comments, CommentRecievedDTO>().ReverseMap();

            CreateMap<WatchedRecieved, Watched>().ReverseMap();

            CreateMap<Queue, QueueAddMovie>().ReverseMap();
            
            CreateMap<User, FriendDTO>().ReverseMap();

            //do wyswietlenia znajomych zalogowanego uzytkownika
            CreateMap<Friend, FriendDTO>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.IdUser1Navigation.Email))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.IdUser1Navigation.Login));
        
            CreateMap<Queue, MovieFromQueue>()
                .ForMember(dest => dest.IdMovie, opt => opt.MapFrom(src => src.IdMovieNavigation.IdMovie))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.IdMovieNavigation.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.IdMovieNavigation.Description))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.IdMovieNavigation.Image));

            CreateMap<Watched, WatchedMovieDTO>()
                .ForMember(dest => dest.IdMovie, opt => opt.MapFrom(src => src.IdMovieNavigation.IdMovie))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.IdMovieNavigation.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.IdMovieNavigation.Description))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.IdMovieNavigation.Image))
                .ForMember(dest => dest.Mark, opt => opt.MapFrom(src => src.Mark));

            CreateMap<Movie, MovieDetails>().ReverseMap();

            CreateMap<CategoryToMovie, CategoryDTO>()
                .ForMember(dest => dest.IdCategory, opt => opt.MapFrom(src => src.IdCategoryNavigation.IdCategory))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.IdCategoryNavigation.Category));

            CreateMap<CategoryToMovie, MovieInfo>()
                .ForMember(dest => dest.IdMovie, opt => opt.MapFrom(src => src.IdMovieNavigation.IdMovie))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.IdMovieNavigation.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.IdMovieNavigation.Description))
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.IdMovieNavigation.Director))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.IdMovieNavigation.Year))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.IdMovieNavigation.Image));
         
            CreateMap<Watched, MovieFriend>()
               .ForMember(dest => dest.IdMovie, opt => opt.MapFrom(src => src.IdMovieNavigation.IdMovie))
               .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.IdMovieNavigation.Title))
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.IdMovieNavigation.Description))
               .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.IdMovieNavigation.Director))
               .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.IdMovieNavigation.Year))
               .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.IdMovieNavigation.Image))
               .ForMember(dest => dest.IdMovie, opt => opt.MapFrom(src => src.Mark));

            CreateMap<Comments, CommentDTO>()
                .ForMember(dest => dest.idUser, opt => opt.MapFrom(src => src.IdUser))
                .ForMember(dest => dest.user, opt => opt.MapFrom(src => src.IdUserNavigation.Login))
                .ForMember(dest => dest.comment, opt => opt.MapFrom(src => src.Comment));
        }
    }
}
