using Liberty.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Repository.Interface
{
    public interface IAuthorSearchParams
    {
        Author CurrentAuthor { get; set; }
        string AuthorLastName { get; set; }
        string AuthorFirstName { get; set; }
    }
}
