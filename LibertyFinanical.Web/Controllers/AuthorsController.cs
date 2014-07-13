using Liberty.Data;
using Liberty.Data.Interfaces;
using Liberty.Repository.Interface;
using LibertyFinanical.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LibertyFinanical.Web.Controllers
{
    [Authorize]
    public class AuthorsController : BaseController
    {

        private IAuthorsRepository _authorsRepository;

        public AuthorsController(IAuthorsRepository authorsRepostory, IDataContext dataContext, ISessionContext context)
            : base(dataContext, context)
        {
            _authorsRepository = authorsRepostory;
        }


        public ActionResult Index()
        {
            return View(new AuthorSearchParams());
        }

        //add new authors
        //find authors
        //edit authors

        public ActionResult _ajaxAuthorSearch(AuthorSearchParams searchTerms)
        {

            var authors = _authorsRepository.GetAuthors(searchTerms);
            return PartialView("DisplayTemplates/Authors", _authorsRepository.GetAuthors(searchTerms));
        }

        [HttpGet]
        public ActionResult _ajaxSaveAuthor()
        {
            return PartialView("EditTemplates/Author", new Author());
        }


        [HttpPost]
        public ActionResult _ajaxSaveAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                var a = _authorsRepository.SaveAuthor(author);
                return View("Index", new AuthorSearchParams(a));
            }
            else
                return View("Index", new AuthorSearchParams());
            
        }
    }
}
