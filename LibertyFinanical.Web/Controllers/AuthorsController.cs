using Liberty.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LibertyFinanical.Web.Controllers
{
    [Authorize]
    public class AuthorsController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        //add new authors
        //find authors
        //edit authors

        public ActionResult _ajaxAuthorSearch(Author author)
        {
            return PartialView("DisplayTemplates/Authors", new List<Author>());
        }

        [HttpGet]
        public ActionResult _ajaxSaveAuthor()
        {
            return PartialView("EditTemplates/Author", new Author());
        }


        [HttpPost]
        public ActionResult _ajaxSaveAuthor(Author author)
        {
            return PartialView("EditTemplates/Author", new Author());
        }
    }
}
