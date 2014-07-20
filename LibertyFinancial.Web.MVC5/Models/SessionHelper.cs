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

        public SessionHelper(IAuthorsRepository authors)
        {
            _authors = authors;
        }

        public IEnumerable<SelectListItem> Authors
        {
            get
            {
                List<SelectListItem> authors;
                if (HttpContext.Current.Session["Authors"] == null)
                {
                    authors = new List<SelectListItem>();
                    var alist = _authors.GetAuthors(null);
                    alist.ForEach(e => authors.Add(new SelectListItem() { Text = e.AuthorFullName, Value = e.AuthorId.ToString() }));
                    HttpContext.Current.Session["Authors"] = authors;
                }
                else
                    authors = HttpContext.Current.Session["Authors"] as List<SelectListItem>;
                return authors;
            }
        }
    }
}