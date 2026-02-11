using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
    public class IdentityRoleConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                    new IdentityRole() {Id = "a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3a3", Name = "User", NormalizedName = "USER" },
                    new IdentityRole() { Id = "a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3a", Name = "Admin", NormalizedName = "ADMIN" },
                    new IdentityRole() { Id = "a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3", Name = "Author", NormalizedName = "AUTHOR" }
                    );
        }
    }
}
