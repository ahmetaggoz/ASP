using BlogProject.Core.Entities;
using BlogProject.Core.Interfaces;
using BlogProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Infrastructure.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(BlogContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Post>> GetPostsByAuthorAsync(string author)
        {
            return await _dbSet.Where(p => p.Author.Equals(author))
                               .OrderByDescending(p => p.CreatedDate)
                               .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPublishedPostsAsync()
        {
            return await _dbSet.Where(p => p.IsPublished)
                               .OrderByDescending(p => p.CreatedDate)
                               .ToListAsync();
        }
    }
}
