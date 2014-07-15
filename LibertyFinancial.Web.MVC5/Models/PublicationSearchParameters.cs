using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibertyFinancial.Web.MVC5.Models
{
    public class PublicationSearchParameters
    {
        public string AuthorLastName { get; set; }
        public string BookTitle { get; set; }
        public string ISBN { get; set; }
    
    }
}