using Liberty.Data.Interfaces;
using LibertyFinanical.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LibertyFinanical.Web.Controllers
{
    public class AccountController : Controller//: BaseController
    {

        public AccountController()
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
            if (model.UserName == "john" && model.Password == "wayne")
            {
                System.Web.Security.FormsAuthentication.SetAuthCookie(model.UserName, true);
                if (Url.IsLocalUrl(returnUrl))
                {
                    //if (returnUrl == "/")
                    //    return RedirectToAction("Index", "Home");
                    //else
                        return Redirect(returnUrl);
                }
                else // keep it safe from phishers!
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View(model);
            }
            
        }
    }
}
