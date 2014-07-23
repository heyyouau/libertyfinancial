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
            options.LoadWith<Publication>(e => e.AuthorPublications);
            options.LoadWith<AuthorPublication>(e => e.Author);
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
            nm.MaxBorrowings = member.MaxBorrowings;

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



            pub.Title = publication.Title;
            pub.ISBN = publication.ISBN;
            pub.Synopsis = publication.Synopsis;
            pub.Copies = publication.Copies;

            return pub;
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

        public IQueryable<MemberCurrentBookBorrowingsWithName> GetMemberBorrowings
        {
            get
            {
                return _dataContext.MemberCurrentBookBorrowingsWithNames;
            }
        }


    }
}
