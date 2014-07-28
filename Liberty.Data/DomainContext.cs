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
           
        }

        public void SaveChanges()
        {
            //would normally save the changes here;
            //_dataContext.SubmitChanges();
        }

        public List<Author> GetAuthors()
        {
            return _dataContext.Authors.ToList();
        }


        public List<Author> GetAuthorsByPublication(int publicationId)
        {
            return (from a in _dataContext.Authors
                    join ap in _dataContext.AuthorPublications
                        on a.AuthorId equals ap.AuthorId
                    where ap.PublicationId == publicationId
                    select a).ToList();
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
                _dataContext.Authors.ToList().Add(upd);
            }

            upd.AuthorFirstName = author.AuthorFirstName;
            upd.AuthorLastName = author.AuthorLastName;

            return upd;
        }


        #region Members

        public List<Member> GetMembers()
        {
            return _dataContext.Members.ToList();
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
                _dataContext.Members.ToList().Add(nm);
            }
            nm.FirstName = member.FirstName;
            nm.LastName = member.LastName;
            nm.ContactNumber = member.ContactNumber;
            nm.MaxBorrowings = member.MaxBorrowings;

            return nm;
        }


        #endregion


        public List<Publication> GetPublicationsByAuthor(string authorName)
        {
            return (from p in _dataContext.Publications
                    join ap in _dataContext.AuthorPublications
                        on p.BookId equals ap.PublicationId
                    join a in _dataContext.Authors
                        on ap.AuthorId equals a.AuthorId
                    where a.AuthorLastName == authorName
                    select p).ToList();
        }




        public List<Publication> GetPublicationsByAuthorId(int authorId)
        {
            return (from p in _dataContext.Publications
                    join ap in _dataContext.AuthorPublications
                        on p.BookId equals ap.PublicationId
                    join a in _dataContext.Authors
                        on ap.AuthorId equals a.AuthorId
                        where a.AuthorId == authorId
                    select p).ToList();
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
                _dataContext.Publications.ToList().Add(pub);
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
                ap = new AuthorPublication(publication, author);
                _dataContext.AuthorPublications.ToList().Add(ap);
            }
                
        }

        public List<Publication> GetPublications()
        {
            var pubs = _dataContext.Publications;
            foreach (var p in pubs)
            {
                p.AuthorPublications.AddRange(_dataContext.AuthorPublications.Where(e => e.PublicationId == p.BookId));
            }
            return _dataContext.Publications.ToList();
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
                _dataContext.AuthorPublications.ToList().Remove(t);
        }

        public void SavePublicationAuthor(int authorid, int publicationId)
        {
            var t = _dataContext.AuthorPublications.FirstOrDefault(e => e.AuthorId == authorid && e.PublicationId == publicationId);

            if (t == null)
                _dataContext.AuthorPublications.ToList().Add(new AuthorPublication() { GetAuthor(authorid),  GetPublication(publicationId) });
        }



        public List<MemberCurrentBookBorrowing> CurrentBookBorrowings
        {
            get
            {
                var results = new List<MemberCurrentBookBorrowing>();
                foreach (var b in _dataContext.Borrowings)
                {
                    var p = GetPublication(b.BookId);
                    var m = GetMember(b.MemberId);
                    var authors = string.Empty;
                    foreach(var a in p.AuthorPublications){
                        authors += a.AuthorFullName + ", ";
                    }
                    results.Add(new MemberCurrentBookBorrowing() { AuthorFullName = authors, BookId = p.BookId, BorrowDate = b.BorrowDate, BorrowingId = b.BorrowingId, DueDate = b.DueDate, ISBN = p.ISBN, MemberId = b.MemberId, Title = p.Title });
                }
                return results;
            }
        }
        public List<BookBorrowingCount> BookBorrowingCount
        {
            get
            {
                var results = new List<BookBorrowingCount>();
                foreach (var b in _dataContext.Borrowings)
                {
                    
                }
                return results;
            }
        }

        public void BorrowBook(int memberId, int publicationId, DateTime eventDate, DateTime dueDate)
        {
            _dataContext.Borrowings.ToList().Add(new Borrowing() { BookId = publicationId, BorrowDate = eventDate, DueDate = dueDate, MemberId = memberId, Returned = false });
        }

        public List<Borrowing> GetBorrowings
        {
            get
            {

                return _dataContext.Borrowings.ToList();
            }
        }

        public List<MemberCurrentBookBorrowingsWithName> GetMemberBorrowings
        {
            get
            {
                var l = new List<MemberCurrentBookBorrowingsWithName>();
                foreach (var mcb in _dataContext.Borrowings)
                {
                    var p = GetPublication(mcb.BookId);
                    var m = GetMember(mcb.MemberId);
                    var authors = "";
                    foreach (var a in p.AuthorPublications)
                    {
                        authors += a.AuthorFullName + ", ";
                    }

                    l.Add(new MemberCurrentBookBorrowingsWithName() { AuthorFullName = authors, ContactNumber = m.ContactNumber, DueDate = mcb.DueDate, FirstName = m.FirstName, LastName = m.LastName, Title = p.Title });
                }
                return l;
            }
        }


    }
}
