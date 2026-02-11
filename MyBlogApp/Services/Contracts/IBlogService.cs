using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBlogService
    {
        IEnumerable<Blog> GetAllBlogs();
        void UpdateBlog(Blog blog);
        void DeleteBlog(Blog blog);
        void CreateBlog(Blog blog);
        Blog? GetBlogById(int id);
    }
}
