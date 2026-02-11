using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{
    public class ClothesConfig : IEntityTypeConfiguration<Clothes>
    {
        public void Configure(EntityTypeBuilder<Clothes> builder)
        {
            builder
                .Property(c => c.Price)
                .HasPrecision(18, 2);
            builder.HasData(

                    new Clothes { Id = 1, Name = "T-Shirt", Price = 19.99m },
                    new Clothes { Id = 2, Name = "Jeans", Price = 49.99m },
                    new Clothes { Id = 3, Name = "Jacket", Price = 89.99m }

            );
        }
    }
}
