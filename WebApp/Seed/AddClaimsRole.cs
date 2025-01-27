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
    public class AddClaimsRole : IEntityTypeConfiguration<RoleManager<Role>>
    {
        public void Configure(EntityTypeBuilder<RoleManager<Role>> builder)
        {
            throw new NotImplementedException();
        }
    }
}