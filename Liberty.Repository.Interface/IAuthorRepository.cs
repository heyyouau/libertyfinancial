using Liberty.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Repository.Interface
{
    public interface IAuthorRepository
    {
        IQueryable<Author> GetAuthors();
        Author GetAuthor(int authorId);
        Author GetAuthor(string firstname, string lastname);
        Author SaveAuthor(Author author);
    }
}
