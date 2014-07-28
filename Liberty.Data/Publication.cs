using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Data
{
    public class Publication
    {
        public BookBorrowingCount BookBorrowing { get; set; }

        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Synopsis { get; set; }
        public int Copies { get; set; }


        private List<AuthorPublication> _authorPublications = new List<AuthorPublication>();

        public List<AuthorPublication> AuthorPublications
        {
            get
            {
                return _authorPublications;
            }
        }

        public bool AvailableForLoan
        {
            get
            {
                return BookBorrowing == null? false : BookBorrowing.Available > 0;
            }
        }
    }
}
