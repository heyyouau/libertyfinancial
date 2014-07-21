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
            var options = new DataLoadOptions();
            options.LoadWith<Publication>(e => e.GenrePublications);
            options.LoadWith<Publication>(e => e.AuthorPublications);

            options.LoadWith<AuthorPublication>(e => e.Author);
            options.LoadWith<GenrePublication>(e => e.Genre);

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


        public IQueryable<Author> GetAuthorsByPublication(int publicationId)
        {
            return (from a in _dataContext.Authors
                    join ap in _dataContext.AuthorPublications
                        on a.AuthorId equals ap.AuthorId
                    where ap.PublicationId == publicationId
                    select a);
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


        public IQueryable<Publication> GetPublicationsByAuthor(string authorName)
        {
            return (from p in _dataContext.Publications
                    join ap in _dataContext.AuthorPublications
                        on p.BookId equals ap.PublicationId
                    join a in _dataContext.Authors
                        on ap.AuthorId equals a.AuthorId
                    where a.AuthorLastName == authorName
                    select p);
        }

        public IQueryable<Publication> GetPublicationsByGenre(List<int> genres)
        {
            return (from p in _dataContext.Publications
                    join ap in _dataContext.GenrePublications
                        on p.BookId equals ap.PublicationId
                    join a in _dataContext.Genres
                        on ap.GenreId equals a.Id
                    where genres.Contains(a.Id)
                    select p);
        }


        public IQueryable<Publication> GetPublicationsByAuthorId(int authorId)
        {
            return (from p in _dataContext.Publications
                    join ap in _dataContext.AuthorPublications
                        on p.BookId equals ap.PublicationId
                    join a in _dataContext.Authors
                        on ap.AuthorId equals a.AuthorId
                        where a.AuthorId == authorId
                    select p);
        }

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

        public IQueryable<Genre> GetGenresByPublication(int publicationId)
        {
            return (from genre in _dataContext.Genres
                    join gp in _dataContext.GenrePublications
                        on genre.Id equals gp.GenreId
                    where gp.PublicationId == publicationId
                    select genre);
        }


        public void DeletePublicationAuthor(int authorid, int publicationId)
        {
            var t = _dataContext.AuthorPublications.FirstOrDefault(e => e.AuthorId == authorid && e.PublicationId == publicationId);

            if (t != null)
                _dataContext.AuthorPublications.DeleteOnSubmit(t);
        }

        public void SavePublicationAuthor(int authorid, int publicationId)
        {
            var t = _dataContext.AuthorPublications.FirstOrDefault(e => e.AuthorId == authorid && e.PublicationId == publicationId);

            if (t == null)
                _dataContext.AuthorPublications.InsertOnSubmit(new AuthorPublication() { AuthorId = authorid, PublicationId = publicationId });
        }

        public void DeletePublicationGenre(int genreid, int publicationId)
        {
            var t = _dataContext.GenrePublications.FirstOrDefault(e => e.GenreId == genreid && e.PublicationId == publicationId);

            if (t != null)
                _dataContext.GenrePublications.DeleteOnSubmit(t);
        }

        public void SavePublicationGenre(int genreid, int publicationId)
        {
            var t = _dataContext.GenrePublications.FirstOrDefault(e => e.GenreId == genreid && e.PublicationId == publicationId);

            if (t == null)
                _dataContext.GenrePublications.InsertOnSubmit(new GenrePublication() { GenreId = genreid, PublicationId = publicationId});
        }
    }
}
