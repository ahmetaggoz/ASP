using BlogProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<IEnumerable<Post>> GetPublishedPostsAsync();
        Task<IEnumerable<Post>> GetPostsByAuthorAsync(string author);
    }
}
