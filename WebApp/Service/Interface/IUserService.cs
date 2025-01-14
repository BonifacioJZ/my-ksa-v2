using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebApp.Dto.Authentication;

namespace WebApp.Service.Interface
{
    public interface IUserService
    {
        Task<SignInResult>LogIn(LoginDto dto);
        void LogOut();
    }
}