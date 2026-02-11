using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IBlogRepository _blogRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IUserRepository _userRepository;

        public RepositoryManager(RepositoryContext context, IBlogRepository blogRepository, ICategoryRepository categoryRepository, ICommentRepository commentRepository, ITagRepository tagRepository, IUserRepository userRepository)
        {
            _context = context;
            _blogRepository = blogRepository;
            _categoryRepository = categoryRepository;
            _commentRepository = commentRepository;
            _tagRepository = tagRepository;
            _userRepository = userRepository;
        }

        public IBlogRepository Blog => _blogRepository;

        public ICategoryRepository Category => _categoryRepository;

        public ICommentRepository Comment => _commentRepository;

        public ITagRepository Tag => _tagRepository;

        public IUserRepository User => _userRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
