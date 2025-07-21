using BlogProject.Application.Services;
using BlogProject.Core.Entities;
using BlogProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _postService.GetPublishedPostsAsync();
            var viewModels = posts.Select(p => new PostViewModel
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                Author = p.Author,
                IsPublished = p.IsPublished,
                ViewCount = p.ViewCount,
                CreatedDate = p.CreatedDate
            });
            return View(viewModels);
        }

        public async Task<IActionResult> Details(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
                return NotFound();

            await _postService.IncrementViewCountAsync(id);

            var viewModel = new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Author = post.Author,
                IsPublished = post.IsPublished,
                ViewCount = post.ViewCount,
                CreatedDate = post.CreatedDate
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var post = new Post
                {
                    Title = model.Title,
                    Content = model.Content,
                    Author = model.Author,
                    IsPublished = model.IsPublished
                };

                await _postService.CreatePostAsync(post);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
