using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace MyBlogApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _manager;

        public BlogController(IBlogService manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var blogs = _manager.GetAllBlogs();
            return View(blogs);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            _manager.CreateBlog(blog);
            return RedirectToAction(nameof(Index));
        }
    }
}
