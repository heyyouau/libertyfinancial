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
        private LibraryModelDataContext _dataContext;

        public DomainContext(LibraryModelDataContext dc)
        {
            _dataContext = dc;
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
                _dataContext.Authors.Add(upd);
            }

            upd.AuthorFirstName = author.AuthorFirstName;
            upd.AuthorLastName = author.AuthorLastName;

            return upd;
        }


        #region Members

        public List<Member> GetMembers()
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
                nm.MemberId = _dataContext.Members.Count() + 1;
                _dataContext.Members.Add(nm);
            }
            nm.FirstName = member.FirstName;
            nm.LastName = member.LastName;
            nm.ContactNumber = member.ContactNumber;
            nm.MaxBorrowings = member.MaxBorrowings;

            return nm;
        }


        #endregion




        public List<Publication> GetPublicationsByAuthor(string authorLastName)
        {
            return _dataContext.Publications.Where(e => e.Authors.Any(x => x.AuthorLastName == authorLastName)).ToList();
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
                pub.BookId = _dataContext.Publications.Count() + 1;
                _dataContext.Publications.Add(pub);
            }

            publication.Authors.RemoveAll(e => e.Delete == true);


            //add any new ap's to the datacontext
           

            pub.Title = publication.Title;
            pub.ISBN = publication.ISBN;
            pub.Synopsis = publication.Synopsis;
            pub.Copies = publication.Copies;

            return pub;
        }

      

      
        public List<Publication> GetPublications()
        {
            var pubs = _dataContext.Publications;
            return _dataContext.Publications;
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
                    results.Add(new MemberCurrentBookBorrowing() { AuthorFullName = p.AuthorNames, BookId = p.BookId, BorrowDate = b.BorrowDate, BorrowingId = b.BorrowingId, DueDate = b.DueDate, ISBN = p.ISBN, MemberId = b.MemberId, Title = p.Title });
                }
                return results;
            }
        }
        

        public void BorrowBook(int memberId, int publicationId, DateTime eventDate, DateTime dueDate)
        {
            _dataContext.Borrowings.Add(new Borrowing() { BookId = publicationId, BorrowDate = eventDate, DueDate = dueDate, MemberId = memberId, Returned = false });
        }

        public List<Borrowing> GetBorrowings
        {
            get
            {

                return _dataContext.Borrowings;
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

                    l.Add(new MemberCurrentBookBorrowingsWithName() { AuthorFullName = p.AuthorNames, ContactNumber = m.ContactNumber, DueDate = mcb.DueDate, FirstName = m.FirstName, LastName = m.LastName, Title = p.Title });
                }
                return l;
            }
        }


    }
}
