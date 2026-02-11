using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class TagRepository : RepositoryBase<Tag>
    {
        public TagRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
