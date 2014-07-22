using Liberty.Data;
using Liberty.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibertyFinancial.Web.MVC5.Models
{
    public class AuthorSearchParams : IAuthorSearchParams
    {

        public AuthorSearchParams()
        {   
            AuthorFirstName = string.Empty;
            AuthorLastName = string.Empty;
        }

        private string _lastname;
        
        public string AuthorLastName 
        {
            get { return _lastname == null ? string.Empty : _lastname; }
            set
            {
                _lastname = value;
            }
        }

        private string _firstname;
        public string AuthorFirstName 
        {
            get { return _firstname == null ? string.Empty : _firstname; }
            set { _firstname = value; }
        }
        
    }
}