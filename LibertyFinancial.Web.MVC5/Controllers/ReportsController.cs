using Liberty.Data.Interfaces;
using Liberty.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibertyFinancial.Web.MVC5.Controllers
{
    public class ReportsController : BaseController
    {
        private IReportsRepository _reportsRepository;

        public ReportsController(IDataContext context, IReportsRepository reportRepoitory)
            : base(context)
        {
            _reportsRepository = reportRepoitory;
        }

        // GET: Reports
        public ActionResult Index()
        {
            return View(_reportsRepository.GetOverDueBooks(7));
        }
    }
}