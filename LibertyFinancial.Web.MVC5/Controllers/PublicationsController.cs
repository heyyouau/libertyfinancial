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
    [Authorize, NoCache]
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



        [HttpGet]
        public ActionResult _ajaxSavePublication()
        {
            return PartialView("EditorTemplates/Publication", new Publication());
        }

        [HttpPost]
        public ActionResult _ajaxSavePublication(Publication publication)
        {
            if (ModelState.IsValid)
            {
                var pub = _publicationRepository.SavePublication(publication);
                ViewBag.SuccessMessage = "Publication Saved";
                return PartialView("EditorTemplates/Publication", pub);
            }
            else
            {
                ViewBag.SuccessMessage = "Publication Save Failed";
                return PartialView("EditorTemplates/Publication", publication);
            }
        }

        public ActionResult _getAuthorSelector()
        {
            var authorSelectorList = new List<SelectableAuthor>();
            _sessionHelper.Authors.ForEach(e => authorSelectorList.Add(new SelectableAuthor(e)));
            return PartialView("EditorTemplates/AuthorSelector", authorSelectorList);
        }



        [HttpGet]
        public ActionResult _editPublication(int id)
        {
            var model = _publicationRepository.GetPublication(id);
            return PartialView("EditorTemplates/Publication", model);
        }

    }
}
