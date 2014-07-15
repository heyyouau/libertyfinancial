using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Repository.Interface
{
    public interface IPublicationSearchParams
    {
        int AuthorId { get; set;}
        string BookTitle { get; set; }
        string ISBN { get; set; }
        string AuthorLastName { get; set; }
        List<int> GenreId { get; set; }
    }
}
