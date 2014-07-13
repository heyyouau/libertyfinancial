using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Repository.Interface
{
    public interface ILogInModel
    {
        string UserName { get; set; }

        string Password { get; set; }
    }
}
