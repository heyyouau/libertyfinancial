using Liberty.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
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

            //always get the deep version of the publication entity
            DataLoadOptions options = new DataLoadOptions();
            options.LoadWith<Publication>(g => g.GenrePublications);
            options.LoadWith<Publication>(a => a.AuthorPublications);
            
            //always get the publications and members with the borrowing
            options.LoadWith<Borrowing>(p => p.Publication);
            options.LoadWith<Borrowing>(m => m.Member);

            options.LoadWith<GenrePublication>(gp => gp.Genre);
            options.LoadWith<AuthorPublication>(ap => ap.Author);

            _dataContext.LoadOptions = options;
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

        public IQueryable<Author> SearchAuthors(string name)
        {
            return _dataContext.Authors.Where(e => e.AuthorLastName.Contains(name));
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


        #region Members

        public IQueryable<Member> GetMembers()
        {
            return _dataContext.Members;
        }


        public Member GetMember(int memberId)
        {
            return _dataContext.Members.First(e => e.MemberId == memberId);
        }


        public Member SaveMember(Member member)
        {
            var nm = _dataContext.Members.FirstOrDefault(e => e.MemberId == member.MemberId);

            if (nm == null)
            {
                nm = new Member();
                _dataContext.Members.InsertOnSubmit(nm);
            }
            nm.FirstName = member.FirstName;
            nm.LastName = member.LastName;
            nm.ContactNumber = member.ContactNumber;

            return nm;
        }


        #endregion


        public Publication GetPublication(int publicationId)
        {
            return _dataContext.Publications.FirstOrDefault(e => e.BookId == publicationId);
        }

        public Publication SavePublication(Publication publication)
        {
            var pub = GetPublication(publication.BookId);

            if (pub == null)
            {
                pub = new Publication();
                _dataContext.Publications.InsertOnSubmit(pub);
            }

            pub.AuthorPublications = publication.AuthorPublications;
            pub.GenrePublications = publication.GenrePublications;
            pub.Title = publication.Title;
            pub.ISBN = publication.ISBN;

            return pub;
        }

        public IQueryable<Publication> GetPublications()
        {
            return _dataContext.Publications;
        }

        public IQueryable<Genre> GetGenres()
        {
            return _dataContext.Genres;
        }
    }
}
