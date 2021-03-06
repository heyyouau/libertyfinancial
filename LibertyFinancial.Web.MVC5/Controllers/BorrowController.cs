﻿using Liberty.Data.Interfaces;
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
    public class BorrowController : BaseController
    {
        private IBorrowerRepository _borrowerRepository;
        private IMemberRepository _memberRepository;
        private IPublicationRepository _publicationRepository;

        public BorrowController(IBorrowerRepository borrowerRepository, IMemberRepository memberRepository, IPublicationRepository publicationRepository, IDataContext dataContext)
            : base(dataContext)
        {
            _borrowerRepository = borrowerRepository;
            _memberRepository = memberRepository;
            _publicationRepository = publicationRepository;
        }
        //
        // GET: /Borrow/
        public ActionResult Index(int id)
        {
            var m = _memberRepository.GetMember(id);
            var b = _borrowerRepository.GetCurrentBookBorrowings(m.MemberId);
            return View(new BorrowingModel(m, b));
        }


        [HttpGet]
        public ActionResult ConfirmBorrow(int memberId, int publicationId)
        {
            var m = _memberRepository.GetMember(memberId);
            var p = _publicationRepository.GetPublication(publicationId);
            var bm = new BorrowingModel(m, p);
            return PartialView("EditorTemplates/Borrowing", bm);
        }


        [HttpPost]
        public ActionResult ConfirmBorrow(BorrowingModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //should really do some checking here to validate the save operation
                    _borrowerRepository.BorrowBook(model);
                    ViewBag.SuccessMessage = "Book Borrowing Recorded";
                    ViewBag.MemberId = model.Member.MemberId;
                    return PartialView("DisplayTemplates/Result");
                }
                catch (Exception ex)
                {
                    ViewBag.SuccessMessage = "There was a problem saving the record";
                    //log the exception and tell someone
                    return PartialView("EditorTemplates/Borrowing", model);
                }
            }
            else
            {
                return PartialView("EditorTemplates/Borrowing", model);
            }
        }


        public ActionResult _ajaxPublicationSearch(PublicationSearchParameters searchParameters, int memberId)
        {
            var matches = _publicationRepository.GetPublications(searchParameters);
            
            ViewBag.MemberId = memberId;
            return PartialView("DisplayTemplates/Publications", matches);
        }


        public ActionResult Return(int borrowingId, int memberId)
        {
            _borrowerRepository.ReturnBook(borrowingId, DateTime.Now);
            return RedirectToAction("Index", new { id = memberId });
        }

	}
}