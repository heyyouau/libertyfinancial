using Liberty.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Liberty.Lib
{
    public class SessionContext : ISessionContext
    {
        private bool _loggedIn;

        public bool IsLoggedIn
        {
            get { return _loggedIn; }
        }

        public bool LogIn(ILogInModel loginModel, ref string message)
        {
            _loggedIn = false;
            //if this was a real application, we would check the database here 
            //for the purposes of this application, if you enter then name john and password wayne, you will get 
            //in as an administrator
            if (loginModel.UserName == "john" && loginModel.Password == "wayne")
                _loggedIn = true;
            else
                message = "The user name or password provided is incorrect.";

            return IsLoggedIn;
        }
    }
}
