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

        public ActionResult _ajaxMemberSearch(MemberSearchTerms parameters)
        {
            return PartialView("DisplayTemplates/Members", _memberRepository.GetMembers(parameters));
        }

        public ActionResult _ajaxSaveMember()
        {
            return PartialView("EditorTemplates/Member", new Member());
        }


        [HttpPost]
        public ActionResult _ajaxSaveMember(Member member)
        {
            var m = _memberRepository.SaveMember(member);
            return PartialView("EditorTemplates/Member", m);
        }

        [HttpGet]
        public ActionResult _editMember(int id)
        {
            var model = _memberRepository.GetMember(id);
            return PartialView("EditorTemplates/Member", model);
        }

    }
}
