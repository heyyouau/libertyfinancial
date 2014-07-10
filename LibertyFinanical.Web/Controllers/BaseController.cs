using Liberty.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibertyFinanical.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IDataContext _dataContext;

        public BaseController(IDataContext context)
        {
            _dataContext = context;
        }

    }
}
