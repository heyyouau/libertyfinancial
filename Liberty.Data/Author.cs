using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Data
{
    [MetadataType(typeof(AuthorMetadata))]
    public partial class Author
    {
    }

    public class AuthorMetadata
    {
        [Display(Name="First Name")]
        public string AuthorFirstName { get; set; }

        [Display(Name="Last Name")]
        public string AuthorLastName { get; set; }

    }
}
