using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Models;

namespace WebApp.Seed
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role{
                    Id = "87e55637-05ef-45e1-8eb9-d881cdefa88b",
                    Name = "Root",
                    NormalizedName="ROOT",
                    Description=""
                },
                new Role{
                    Id = "8d1348e5-a2c7-4a7a-8cb4-b7ccb2d2b9c9",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    Description=""
                },
                new Role{
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName="USER",
                    Description=""
                }
            );
        }
    }
}