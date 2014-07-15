using Liberty.Data.Interfaces;
using Liberty.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibertyFinancial.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public HomeController(IDataContext dataContext, ISessionContext context)
            : base(dataContext, context)
        {

        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
