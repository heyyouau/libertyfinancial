using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Data
{
    public class LibraryModelDataContext
    {

        private List<Author> _authors = new List<Author>();
        private List<Publication> _publications = new List<Publication>();
        private List<Member> _members = new List<Member>();
        private List<Borrowing> _borrowings = new List<Borrowing>();

        public LibraryModelDataContext()
        {
            //seed with dummy data
            _authors.Add(new Author() { AuthorFirstName = "Terry", AuthorLastName = "Pratchett", AuthorId = 1});
            _authors.Add(new Author() { AuthorFirstName = "John", AuthorLastName = "Saffran", AuthorId = 2});
            _authors.Add(new Author() { AuthorFirstName = "Neil", AuthorLastName = "Gamon", AuthorId = 3 });
            _authors.Add(new Author() { AuthorFirstName = "Clive", AuthorLastName = "Barker", AuthorId = 4 });


            var pub = new Publication() { Title = "The colour of magic", Copies = 3, ISBN = "XSSDFDSFSERER", BookId = 1, AvailableCopies = 2 };
            var pub2 = new Publication() { Title = "Murder in Mississippi", Copies = 3, ISBN = "DSFGDGDFG", BookId = 2, AvailableCopies = 2 };
            var pub3 = new Publication() { Title = "Good Omens", Copies = 3, ISBN = "304985035=2234234-22234234", BookId = 3, AvailableCopies = 1};
            var pub4 = new Publication() { Title = "The Great and Secret Show", Copies = 1, ISBN = "404985035=2234234-22234234", BookId = 4, AvailableCopies = 0};

            pub.Authors.Add(_authors[0]);
            pub2.Authors.Add(_authors[1]);
            pub3.Authors.Add(_authors[2]);
            pub3.Authors.Add(_authors[0]);
            pub4.Authors.Add(_authors[3]);

            _publications.Add(pub);
            _publications.Add(pub2);
            _publications.Add(pub3);
            _publications.Add(pub4);

            _members.Add(new Member() { MemberId = 1, FirstName = "John", LastName = "Wayne", ContactNumber = "34530333" , MaxBorrowings = 3});
            _members.Add(new Member() { MemberId = 2, FirstName = "Jimmy", LastName = "Stewart", ContactNumber = "4564664", MaxBorrowings = 6 });
            _members.Add(new Member() { MemberId = 3, FirstName = "Bella", LastName = "Lugosi", ContactNumber = "4454564646", MaxBorrowings = 6 });

            _borrowings.Add(new Borrowing() { BookId = 1, BorrowDate = new DateTime(2014, 6, 6), BorrowingId = _borrowings.Count + 1, DueDate = new DateTime(2014, 7, 6), MemberId = 1, Returned = false });
            _borrowings.Add(new Borrowing() { BookId = 2, BorrowDate = new DateTime(2014, 7, 29), BorrowingId = _borrowings.Count + 1, DueDate = new DateTime(2014, 8, 14), MemberId = 1, Returned = false });
            _borrowings.Add(new Borrowing() { BookId = 3, BorrowDate = new DateTime(2014, 7, 14), BorrowingId = _borrowings.Count + 1, DueDate = new DateTime(2014, 7, 31), MemberId = 1, Returned = false });
            _borrowings.Add(new Borrowing() { BookId = 3, BorrowDate = new DateTime(2014, 7, 14), BorrowingId = _borrowings.Count + 1, DueDate = new DateTime(2014, 7, 31), MemberId = 1, Returned = false });
            _borrowings.Add(new Borrowing() { BookId = 4, BorrowDate = new DateTime(2014, 7, 14), BorrowingId = _borrowings.Count + 1, DueDate = new DateTime(2014, 7, 31), MemberId = 1, Returned = false });


            
        }


        public List<Borrowing> Borrowings
        {
            get
            {
                return _borrowings;
            }
        }


        public List<Member> Members
        {
            get
            {
                return _members;
            }
        }


        public List<Publication> Publications
        {
            get
            {
                return _publications;
            }
        }

        public List<Author> Authors
        {
            get
            {
                return _authors;
            }
        }
    }
}
