using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Data.Interfaces
{
    public interface IDataContext
    {

        void SaveChanges();

        IQueryable<Author> GetAuthors();

        Author GetAuthor(int authorId);

        Author SaveAuthor(Author author);
    }
}
