using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IBlogRepository : IRepositoryBase<Blog>
    {
        IEnumerable<Blog> GetAllBlogs();
        void CreateBlog(Blog blog);
        void DeleteBlog(Blog blog);
        void UpdateBlog(Blog blog);
        Blog? GetBlogById(int id);

    }
}
