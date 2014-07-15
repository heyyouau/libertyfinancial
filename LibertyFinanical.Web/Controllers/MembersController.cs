using Liberty.Data.Interfaces;
using Liberty.Repository.Interface;
using LibertyFinancial.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibertyFinancial.Web.Controllers
{
    public class MembersController : BaseController
    {
        private IMemberRepository _memberRepository;
        //
        // GET: /Members/
        public MembersController(IMemberRepository membersRepository, ISessionContext sessionContext, IDataContext dataContext):base(dataContext, sessionContext)
        {
            _memberRepository = membersRepository;
        }

        public ActionResult Index()
        {
            return View(new MemberSearchTerms());
        }

    }
}
