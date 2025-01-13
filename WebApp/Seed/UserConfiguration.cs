using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Models;

namespace WebApp.Seed
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var user = new User(){
                Id="6f41b021-3b66-484f-a673-7596f9c1aa07",
                FirstName="Admin",
                LastNAme="Root",
                Email="root@root.com",
                UserName="Root",
                NormalizedUserName="ROOT",
                NormalizedEmail="ROOT@ROOT.COM"
            };
            builder.HasData(user);
            
            var passwordHash = new PasswordHasher<User>();
            user.PasswordHash = passwordHash.HashPassword(user,"root");
        }
    }
}