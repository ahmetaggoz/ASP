using Entities;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext context) : base(context) { }
        public void CreateAuthor(Author author) => Create(author);


        public void DeleteAuthor(Author author) => Delete(author);


        public IEnumerable<Author> GetAllAuthors() => FindAll(true);


        public Author? GetAuthorById(int id) => FindByCondition(a => a.Id.Equals(id),true);


        public void UpdateAuthor(Author author) => Update(author);
        
    }
}
