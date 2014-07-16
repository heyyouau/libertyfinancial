﻿using Liberty.Data;
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
        public PublicationsController(IPublicationRepository publicationRepository, IAuthorsRepository authorRepository, IDataContext dataContext, ISessionContext sessionContext):base(dataContext, sessionContext)
        {
            _publicationRepository = publicationRepository;
            _authorsRepository = authorRepository;
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
            return PartialView("EditTemplates/Publication", new Publication());
        }

        public ActionResult _getAuthorSelector()
        {
            return PartialView("EditTemplates/Authors", _authorsRepository.GetAuthors(null));
        }

        public ActionResult _addAuthor()
        {

        }
    }
}
