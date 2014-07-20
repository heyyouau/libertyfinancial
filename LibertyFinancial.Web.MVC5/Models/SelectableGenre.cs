using Liberty.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibertyFinancial.Web.MVC5.Models
{
    public class SelectableGenre
    {
        public SelectableGenre(Genre genre)
        {
            this.GenreID = genre.Id;
            this.GenreName = genre.GenreName;
        }

        public int GenreID { get; set; }

        public string GenreName { get; set; }
    }
}