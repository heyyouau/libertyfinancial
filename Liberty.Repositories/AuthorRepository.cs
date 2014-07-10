using Liberty.Data;
using Liberty.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {

        public AuthorRepository()
        {

        }

        public IQueryable<Author> GetAuthors()
        {
            throw new NotImplementedException();
        }

        public Author GetAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public Author GetAuthor(string firstname, string lastname)
        {
            throw new NotImplementedException();
        }

        public Author SaveAuthor(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
