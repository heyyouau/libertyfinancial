using Liberty.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibertyFinancial.Web.MVC5.Models
{
    public class MemberSearchTerms : IMemberSearchTerms
    {
        public string FirstName  {get;set;}

        public string LastName { get; set; }

        public string ContactNumber { get; set; }
    }
}