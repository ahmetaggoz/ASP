using Entities;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BlogService : IBlogService
    {
        private readonly IRepositoryBase<Blog> _manager;

        public BlogService(IRepositoryBase<Blog> manager)
        {
            _manager = manager;
        }

        public void CreateBlog(Blog blog)
        {
            _manager.Create(blog);
        }

        public void DeleteBlog(Blog blog)
        {
            _manager.Delete(blog);
        }

        public IEnumerable<Blog> GetAllBlogs()
        {
            return _manager.FindAll(false);
        }

        public Blog? GetBlogById(int id)
        {
            return _manager.FindByCondition(b => b.Id.Equals(id), false);
        }

        public void UpdateBlog(Blog blog)
        {
            _manager.Update(blog);
        }
    }
}
