using Liberty.Data.Interfaces;
using Liberty.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibertyFinancial.Web.MVC5.Controllers
{
    public class BaseController : Controller
    {
        private IDataContext _dataContext;


        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            _dataContext.SaveChanges();
            base.OnResultExecuted(filterContext);
        }
        

        public BaseController(IDataContext dataContext)
        {
            _dataContext = dataContext;

        }

    }
}
