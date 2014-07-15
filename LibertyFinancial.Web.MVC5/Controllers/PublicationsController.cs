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
        public PublicationsController(IPublicationRepository publicationRepository, IDataContext dataContext, ISessionContext sessionContext):base(dataContext, sessionContext)
        {
            _publicationRepository = publicationRepository;
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult _ajaxAddGenre()
        {
            return PartialView("EditTemplates/Genre", _publicationRepository.GetGenres());
        }

        [HttpGet]
        public ActionResult _ajaxSavePublication()
        {
            return PartialView("EditTemplates/Publication", new PublicationEditor(new Publication(), _publicationRepository.GetGenres()));
        }
    }
}
