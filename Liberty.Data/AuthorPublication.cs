using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Data
{
    public  class AuthorPublication
    {
        private Data.Publication pub;

        public AuthorPublication()
        {

        }

        public AuthorPublication(Data.Publication pub, Data.Author author)
        {
            // TODO: Complete member initialization
            Publication = pub;
            Author = author;
        }
        public int AuthorId
        {
            get
            {
                if (Author != null)
                    return Author.AuthorId;
                return -1;
            }
        }


        public int PublicationId
        {
            get
            {
                if (Publication != null)
                    return Publication.BookId;
                return -1;
            }
        }

        public Author Author { get; set; }
        public Publication Publication { get; set; }

        public bool Delete { get; set; }
        public string AuthorFullName 
        { 
            get 
            {
                return this.Author.AuthorFullName;
            } 
       }
    }
}
