using Liberty.Data;
using Liberty.Data.Interfaces;
using Liberty.Repository.Interface;
using LibertyFinancial.Web.MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LibertyFinancial.Web.MVC5.Controllers
{
    [NoCache]
    public class AuthorsController : BaseController
    {

        private IAuthorsRepository _authorsRepository;

        public AuthorsController(IAuthorsRepository authorsRepostory, IDataContext dataContext)
            : base(dataContext)
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
            return PartialView("EditorTemplates/Author", new Author());
        }


        [HttpPost]
        public ActionResult _ajaxSaveAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //should really do some checking here to validate the save operation
                    var a = _authorsRepository.SaveAuthor(author);
                    ViewBag.SuccessMessage = "Author Saved";
                    return View("EditorTemplates/Author", a);
                }
                catch (Exception ex)
                {
                    ViewBag.SuccessMessage = "There was a problem saving the record";
                    //log the exception somewhere and then tell someone who cares
                    return View("EditorTemplates/Author", author);
                }
            }
            else
            {
                ViewBag.SuccessMessage = "Author Save Failed";
                return View("EditorTemplates/Author", author);
            }
            
        }


        public ActionResult Edit(int id)
        {
            return PartialView("EditorTemplates/Author", _authorsRepository.GetAuthor(id));
        }

    }
}
