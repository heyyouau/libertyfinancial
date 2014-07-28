using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Data
{
    class LibraryModelDataContext
    {

        private List<AuthorPublication> _authorpublications = new List<AuthorPublication>();
        private List<Author> _authors = new List<Author>();
        private List<Publication> _publications = new List<Publication>();
        private List<Member> _members = new List<Member>();
        private List<Borrowing> _borrowings = new List<Borrowing>();

        public LibraryModelDataContext()
        {
            //seed with dummy data
            _authors.Add(new Author() { AuthorFirstName = "Terry", AuthorLastName = "Pratchett", AuthorId = _authors.Count });
            _authors.Add(new Author() { AuthorFirstName = "John", AuthorLastName = "Saffran", AuthorId = _authors.Count });


            var pub = new Publication() { Title = "The colour of magic", Copies = 3, ISBN = "XSSDFDSFSERER", BookId = _publications.Count};
            _authorpublications.Add(new AuthorPublication(pub, _authors[0]));
            var pub2 = new Publication() { Title = "Murder in Mississippi", Copies = 3, ISBN = "DSFGDGDFG", BookId = _publications.Count };

            _publications.Add(pub);
            _publications.Add(pub2);
            
        }

        public IQueryable<AuthorPublication> AuthorPublications
        {
            get
            {
                return _authorpublications.AsQueryable();
            }
        }

        public IQueryable<Borrowing> Borrowings
        {
            get
            {
                return _borrowings.AsQueryable();
            }
        }


        public IQueryable<Member> Members
        {
            get
            {
                return _members.AsQueryable();
            }
        }


        public IQueryable<Publication> Publications
        {
            get
            {
                return _publications.AsQueryable();
            }
        }

        public IQueryable<Author> Authors
        {
            get
            {
                return _authors.AsQueryable();
            }
        }
    }
}
