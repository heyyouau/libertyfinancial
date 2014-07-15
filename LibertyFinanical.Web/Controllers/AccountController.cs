using Liberty.Data.Interfaces;
using Liberty.Repository.Interface;
using LibertyFinancial.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LibertyFinancial.Web.Controllers
{
    public class AccountController : BaseController
    {

        public AccountController(IDataContext dataContext, ISessionContext context)
            : base(dataContext, context)
        {

        }
        
        //public AccountController(IDataContext context):base(context)    
        //{
                
        //}
        
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
           //if this was a real application, we would check the database here 
           //for the purposes of this application, if you enter then name john and password wayne, you will get 
           //in as an administrator
            var errorMessage = string.Empty;

            if (_sessionContext.LogIn(model, ref errorMessage ))
            {
                System.Web.Security.FormsAuthentication.SetAuthCookie(model.UserName, true);
                if (Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
                else // keep it safe from phishers!
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", errorMessage);
                return View(model);
            }
            
        }
    }
}
