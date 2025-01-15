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
        Task<bool> ExistUserName(string userName);
        Task<bool> ExistEmail(string email);
        Task<SignInResult>LogIn(LoginDto dto);
        Task<IdentityResult> Register(RegisterDto dto);
        void LogOut();
    }
}