using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Seed
{
    public class RoleUserConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(new IdentityUserRole<string>{
                UserId ="6f41b021-3b66-484f-a673-7596f9c1aa07",
                RoleId="87e55637-05ef-45e1-8eb9-d881cdefa88b"
            });
        }
    }
}