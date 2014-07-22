using Liberty.Repository.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibertyFinancial.Web.MVC5.Models
{
    public class MemberSearchTerms : IMemberSearchTerms
    {
        public MemberSearchTerms()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            ContactNumber = string.Empty;
        }

        private string _firstName;
        [Display(Name = "First Name")]
        public string FirstName  
        {
            get { return _firstName == null ? string.Empty : _firstName; }
            set
            {
                _firstName = value;
            }
        }

        private string _lastName;

        [Display(Name = "Last Name")]
        public string LastName
        {
            get
            {
                return _lastName == null ? string.Empty : _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        private string _contactNumber;
        [Display(Name = "Contact Number")]
        public string ContactNumber
        {
            get
            {
                return _contactNumber == null ? string.Empty : _contactNumber;
            }
            set
            {
                _contactNumber = value;
            }
        }
    }
}