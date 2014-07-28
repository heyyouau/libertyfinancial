using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Data
{
    public class Publication
    {
        

        private int _bookId;

        public int BookId
        {
            get { return _bookId; }
            set { _bookId = value; }
        }

        private string _title;

        [Required(ErrorMessage = "Please enter the title")]
        public string Title
        {
            get { return string.IsNullOrEmpty(_title)?string.Empty:_title; }
            set { _title = value; }
        }

        private string _isbn;


        [Required(ErrorMessage = "Please enter the ISBN")]
        public string ISBN  
        {
            get { return string.IsNullOrEmpty(_isbn) ? string.Empty:_isbn; }
            set { _isbn = value; }
        }

        private string _synopsis;

        public string Synopsis
        {
            get { return _synopsis; }
            set { _synopsis = value; }
        }

        private int _copies;


        [Required(ErrorMessage = "Please enter the total number of copies")]
        public int Copies
        {
            get { return _copies; }
            set { _copies = value; }
        }


        public string AuthorNames
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var a in Authors)
                {
                    sb.Append(a.AuthorFullName + ", ");
                }

                return sb.ToString().Substring(0, sb.ToString().Length - 2);
            }
        }

        private List<Author> _authors = new List<Author>();

        public List<Author> Authors
        {
            get
            {
                return _authors;
            }
        }


        private int _availableCopies;

        public int AvailableCopies
        {
            get { return _availableCopies; }
            set { _availableCopies = value; }
        }
        


        public bool AvailableForLoan
        {
            get
            {
                return AvailableCopies > 0;
            }
        }


    }
}
