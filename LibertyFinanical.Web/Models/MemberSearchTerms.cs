using Liberty.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibertyFinanical.Web.Models
{
    public class MemberSearchTerms : IMemberSearchTerms
    {
        public string FirstName  {get;set;}

        public string LastName { get; set; }

        public string ContactNumber { get; set; }
    }
}