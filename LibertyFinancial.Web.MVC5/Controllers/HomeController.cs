﻿using Liberty.Data.Interfaces;
using Liberty.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibertyFinancial.Web.MVC5.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public HomeController(IDataContext dataContext)
            : base(dataContext)
        {

        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
