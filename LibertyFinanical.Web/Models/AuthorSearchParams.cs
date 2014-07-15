using Liberty.Data;
using Liberty.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibertyFinancial.Web.Models
{
    public class AuthorSearchParams : IAuthorSearchParams
    {

        public AuthorSearchParams()
        {
            
            AuthorFirstName = string.Empty;
            AuthorLastName = string.Empty;
        }

        private Author _currentAuthor = new Author();

        public AuthorSearchParams(Author currentAuthor):this()
        {
            _currentAuthor = currentAuthor;
        }
        public string AuthorLastName { get; set; }

        public Author CurrentAuthor
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string AuthorFirstName { get; set; }
        
    }
}