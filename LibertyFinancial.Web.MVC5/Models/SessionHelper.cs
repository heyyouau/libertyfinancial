using Liberty.Data;
using Liberty.Data.Interfaces;
using Liberty.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibertyFinancial.Web.MVC5.Models
{
    public class SessionHelper
    {
        private IAuthorsRepository _authors;
        private IPublicationRepository _publications;

        public SessionHelper(IAuthorsRepository authors, IPublicationRepository publications)
        {
            _authors = authors;
            _publications = publications;
        }

        public List<Author> Authors
        {
            get
            {
                List<Author> authors;
                if (HttpContext.Current.Session["Authors"] == null)
                {
                    authors = _authors.GetAuthors(null).ToList();
                    HttpContext.Current.Session["Authors"] = authors;
                }
                else
                    authors = HttpContext.Current.Session["Authors"] as List<Author>;
                return authors;
            }
        }

        public List<Genre> Genres
        {
            get
            {
                List<Genre> genres;
                if (HttpContext.Current.Session["Genres"] == null)
                {
                    genres = _publications.GetGenres().ToList();
                    HttpContext.Current.Session["Genres"] = genres;
                }
                else
                    genres = HttpContext.Current.Session["Genres"] as List<Genre>;
                return genres;

            }
        }
    }
}