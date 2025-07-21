using BlogProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Infrastructure.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Content).IsRequired();
                entity.Property(e => e.Author).IsRequired().HasMaxLength(100);
            });

            // Seed data
            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, Title = "İlk Blog Yazısı", Content = "Bu ilk blog yazımın içeriği...", Author = "Admin", IsPublished = true },
                new Post { Id = 2, Title = "ASP.NET Core Hakkında", Content = "ASP.NET Core modern web geliştirme...", Author = "Developer", IsPublished = true },
                new Post { Id = 3, Title = "Taslak Yazı", Content = "Bu henüz tamamlanmamış bir yazı...", Author = "Writer", IsPublished = false }
            );
        }
    }
}
