using Liberty.Data.Interfaces;
using Liberty.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibertyFinanical.Web.Controllers
{
    public class PublicationController : BaseController
    {
        private IPublicationRepository _publicationRepository;
        public PublicationController(IPublicationRepository publicationRepository, IDataContext dataContext, ISessionContext sessionContext):base(dataContext, sessionContext)
        {
            _publicationRepository = publicationRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
