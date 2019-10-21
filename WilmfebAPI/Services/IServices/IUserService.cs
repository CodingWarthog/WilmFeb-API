using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WilmfebAPI.DTOModels;
using WilmfebAPI.Models;

namespace WilmfebAPI.Services.IServices
{
    public interface IUserService
    {
        IActionResult AuthenticateUser(UserSignIn userSignIn);
        IActionResult RegisterNewUser(UserSignIn userSignIn);
        User CheckUserByLoginAndPassword(string login, string password);
        void Create(User user, string password);
        User GetById(int id);
    }
}
