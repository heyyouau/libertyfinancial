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

            options.LoadWith<Member>(e => e.Borrowings);


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

            //delete ap's marked for deletion from the datacontext
            foreach (var ap in publication.AuthorPublications.Where(e => e.Delete))
            {
                DeletePublicationAuthor(ap.AuthorId, ap.PublicationId);
            }

            //add any new ap's to the datacontext
            foreach (var ap in publication.AuthorPublications.Where(e => !(pub.AuthorPublications.Contains(e))))
            {
                AddAuthorPublication(GetAuthor( ap.AuthorId), pub);
            }


            //delete any gp's marked for deletion
            foreach (var ap in publication.GenrePublications.Where(e => e.Delete))
            {
                DeletePublicationGenre(ap.GenreId, ap.PublicationId);
            }



            //add any new gp's not yet in the data context
            foreach (var ap in publication.GenrePublications.Where(e => !(pub.GenrePublications.Contains(e))))
            {
                AddGenrePublication(GetGenre(ap.GenreId), pub);
            }

            pub.Title = publication.Title;
            pub.ISBN = publication.ISBN;
            pub.Synopsis = publication.Synopsis;
            pub.Copies = publication.Copies;

            return pub;
        }

        private void AddGenrePublication(Genre genre, Publication publication)
        {
            var gp = _dataContext.GenrePublications.FirstOrDefault(e => e.Genre == genre && e.Publication == publication);

            if (gp == null)
            {
                gp = new GenrePublication() { Genre = genre, Publication = publication };
                _dataContext.GenrePublications.InsertOnSubmit(gp);
            }

        }

        private void AddAuthorPublication(Author author, Publication publication)
        {
            var ap = _dataContext.AuthorPublications.FirstOrDefault(e => e.Author == author && e.Publication == publication);

            if (ap == null)
            {
                ap = new AuthorPublication() { Author = author, Publication = publication};
                _dataContext.AuthorPublications.InsertOnSubmit(ap);
            }
                
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

        //public void DeletePublicationAuthor(AuthorPublication ap)
        //{
        //    var t = _dataContext.AuthorPublications.FirstOrDefault(e => e.AuthorId == authorid && e.PublicationId == publicationId);
        //    _dataContext.AuthorPublications.DeleteOnSubmit(ap);
        //}
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


        public Genre GetGenre(int genreId)
        {
            return _dataContext.Genres.FirstOrDefault(e => e.Id == genreId);
        }


        public IQueryable<MemberCurrentBookBorrowing> CurrentBookBorrowings
        {
            get
            {
                return _dataContext.MemberCurrentBookBorrowings;
            }
        }
        public IQueryable<BookBorrowingCount> BookBorrowingCount
        {
            get
            {
                return _dataContext.BookBorrowingCounts;
            }
        }

        public void BorrowBook(int memberId, int publicationId, DateTime eventDate, DateTime dueDate)
        {
            _dataContext.Borrowings.InsertOnSubmit(new Borrowing() { BookId = publicationId, BorrowDate = eventDate, DueDate = dueDate, MemberId = memberId, Returned = false });
        }

        public IQueryable<Borrowing> GetBorrowings
        {
            get
            {
                return _dataContext.Borrowings;
            }
        }
    }
}
