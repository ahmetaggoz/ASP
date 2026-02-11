using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CommentRepository : RepositoryBase<Comment>
    {
        public CommentRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
