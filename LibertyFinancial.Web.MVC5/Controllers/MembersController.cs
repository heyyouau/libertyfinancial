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
    [NoCache]
    public class MembersController : BaseController
    {
        private IMemberRepository _memberRepository;
        //
        // GET: /Members/
        public MembersController(IMemberRepository membersRepository, IDataContext dataContext):base(dataContext)
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

            if (ModelState.IsValid)
            {
                try
                {
                    //should be checking the result to validate the operation
                    var m = _memberRepository.SaveMember(member);
                    ViewBag.SuccessMessage = "Member Saved";
                    return PartialView("EditorTemplates/Member", m);
                }
                catch (Exception ex)
                {
                    ViewBag.SuccessMessage = "There was a problem saving the record";
                    //log the exception and tell someone
                    return PartialView("EditorTemplates/Member", member);
                }
            }
            else
            {
                return PartialView("EditorTemplates/Member", member);
            }
        }

        [HttpGet]
        public ActionResult _editMember(int id)
        {
            var model = _memberRepository.GetMember(id);
            return PartialView("EditorTemplates/Member", model);
        }

    }
}
