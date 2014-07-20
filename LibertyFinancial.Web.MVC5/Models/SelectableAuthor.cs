using Liberty.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibertyFinancial.Web.MVC5.Models
{
    public class SelectableAuthor 
    {
        public SelectableAuthor(Author a)
        {
            this.AuthorName = a.AuthorFullName;
            this.AuthorId = a.AuthorId;
        }

        public string AuthorName { get; set; }
        public int AuthorId { get; set; }
    }
}