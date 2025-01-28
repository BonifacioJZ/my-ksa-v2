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
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasData(
                new Permission(){
                    Id = "e0cfe636-34ac-4ec3-9ebb-6b93d34d2068",
                    Name="SuperUser",
                    Description="",
                    NormalizeName="SUPERUSER"
                },
                new Permission(){
                    Id = Guid.NewGuid().ToString(),
                    Name="Create",
                    Description="",
                    NormalizeName="CREATE"
                },
                new Permission(){
                    Id = Guid.NewGuid().ToString(),
                    Name="Read",
                    Description="",
                    NormalizeName="READ"
                },
                new Permission(){
                    Id=Guid.NewGuid().ToString(),
                    Name="Delete",
                    Description="",
                    NormalizeName="DELETE"
                },
                new Permission(){
                    Id = Guid.NewGuid().ToString(),
                    Name="Update",
                    Description="",
                    NormalizeName="UPDATE"
                }
            );
        }
    }
}