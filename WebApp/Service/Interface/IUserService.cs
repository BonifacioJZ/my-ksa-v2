using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebApp.Dto.Authentication;
using WebApp.Dto.User;
using WebApp.Models;

namespace WebApp.Service.Interface
{
    public interface IUserService
    {
        Task<bool> ExistUserName(string userName);
        Task<bool> ExistEmail(string email);
        IQueryable<User> All();
        Task<UserDetailsDto> GetById(Guid id);
        Task<SignInResult>LogIn(LoginDto dto);
        Task<IdentityResult> Register(RegisterDto dto);
        void LogOut();
        Task<IList<string>> GetRoleByUser(User user);
    }
}