using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Repository.Interface
{
    public interface IMemberSearchTerms
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string ContactNumber { get; set; }

    }
}
