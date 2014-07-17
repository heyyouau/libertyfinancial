using Liberty.Data;
using Liberty.Data.Interfaces;
using Liberty.Repository.Interface;
using LibertyFinancial.Web.MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibertyFinancial.Web.MVC5.Controllers
{
    public class PublicationsController : BaseController
    {
        private IPublicationRepository _publicationRepository;
        private IAuthorsRepository _authorsRepository;
        private SessionHelper _sessionHelper;
        public PublicationsController(IPublicationRepository publicationRepository, IAuthorsRepository authorRepository, SessionHelper helper, IDataContext dataContext, ISessionContext sessionContext):base(dataContext, sessionContext)
        {
            _publicationRepository = publicationRepository;
            _authorsRepository = authorRepository;
            _sessionHelper = helper;
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult _ajaxPublicationSearch(PublicationSearchParameters parameters)
        {
            return PartialView("DisplayTemplates/Publications", _publicationRepository.GetPublications(parameters));
        }


        public ActionResult _ajaxAddGenre()
        {
            return PartialView("EditTemplates/Genre", _publicationRepository.GetGenres());
        }

        [HttpGet]
        public ActionResult _ajaxSavePublication()
        {
            return PartialView("EditorTemplates/Publication", new Publication());
        }

        [HttpPost]
        public ActionResult _ajaxSavePublication(Publication publication)
        {
           var pub =  _publicationRepository.SavePublication(publication);
           return PartialView("EditorTemplates/Publication", pub);
        }

        public ActionResult _getAuthorSelector()
        {
            ViewBag.AuthorSelectList = _sessionHelper.Authors;
            return PartialView("EditorTemplates/Authors", _authorsRepository.GetAuthors(null));
        }

        [HttpGet]
        public ActionResult _editPublication(int id)
        {
            var model = _publicationRepository.GetPublication(id);
            return PartialView("EditorTemplates/Publication", model);
        }



        public ActionResult _addAuthor()
        {
            return null;
        }
    }
}
