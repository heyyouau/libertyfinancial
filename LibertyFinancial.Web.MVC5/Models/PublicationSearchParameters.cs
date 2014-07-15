using Liberty.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibertyFinancial.Web.MVC5.Models
{
    public class PublicationSearchParameters : IPublicationSearchParams 
    {
        public PublicationSearchParameters()
        {
            GenreId = new List<int>();
        }

        public string AuthorLastName { get; set; }
        public string BookTitle { get; set; }
        public string ISBN { get; set; }
        public int AuthorId { get; set; }
        public List<int> GenreId { get; set; }
    }
}