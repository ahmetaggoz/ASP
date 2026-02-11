using Entities;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BlogRepository : RepositoryBase<Blog>, IBlogRepository
    {   

        public BlogRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateBlog(Blog blog) => Create(blog);


        public void DeleteBlog(Blog blog) => Delete(blog);
        

        public IEnumerable<Blog> GetAllBlogs() => FindAll(true);

        public Blog? GetBlogById(int id) => FindByCondition(b => b.Id.Equals(id),true);


        public void UpdateBlog(Blog blog) => Update(blog);
        
    }
}
