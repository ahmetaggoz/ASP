using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IBlogService BlogService { get; }
        ICategoryService CategoryService { get; }
        ICommentService CommentService { get; }
        ITagService TagService { get; }
        IUserService UserService { get; }
    }
}
