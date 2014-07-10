using Liberty.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Data
{
    public class DomainContext : IDataContext
    {
        private LibraryModelDataContext _dataContext = new LibraryModelDataContext();

        public DomainContext()
        {

        }

        public void SaveChanges()
        {
            _dataContext.SubmitChanges();
        }

        public IQueryable<Author> GetAuthors()
        {
            return _dataContext.Authors;
        }

        public Author GetAuthor(int authorId)
        {
            return _dataContext.Authors.FirstOrDefault(e => e.AuthorId == authorId);
        }

        public List<Author> SearchAuthors(string name)
        {
            return _dataContext.Authors.Where(e => e.AuthorLastName.Contains(name)).ToList();
        }

        public Author SaveAuthor(Author author)
        {
            //does it exist?
            var upd = (from a in _dataContext.Authors
                       where a.AuthorId == author.AuthorId 
                       select a).FirstOrDefault();

            if (upd == null)
            {
                upd = new Author();
                _dataContext.Authors.InsertOnSubmit(upd);
            }

            upd.AuthorFirstName = author.AuthorFirstName;
            upd.AuthorLastName = author.AuthorLastName;

            return upd;
        }
    }
}
