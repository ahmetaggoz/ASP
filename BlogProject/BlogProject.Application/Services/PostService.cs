using BlogProject.Core.Entities;
using BlogProject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
            return await _postRepository.AddAsync(post);
        }

        public async Task DeletePostAsync(int id)
        {
            await _postRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _postRepository.GetAllAsync();
        }

        public async Task<Post?> GetPostByIdAsync(int id)
        {
            return await _postRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Post>> GetPublishedPostsAsync()
        {
            return await _postRepository.GetPublishedPostsAsync();
        }

        public async Task IncrementViewCountAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if(post is not null)
            {
                post.ViewCount++;
                await _postRepository.UpdateAsync(post);
            }
        }

        public async Task UpdatePostAsync(Post post)
        {
            await _postRepository.UpdateAsync(post);
        }
    }
}
