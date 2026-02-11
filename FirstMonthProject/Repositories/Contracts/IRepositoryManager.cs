using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IBlogRepository Blog { get; }
        ICategoryRepository Category { get; }
        ICommentRepository Comment { get; }
        ITagRepository Tag { get; }
        IUserRepository User { get; }
        void Save();
    }
}
