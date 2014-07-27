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
       
        public bool Delete { get; set; }

        public string AuthorFullName
        {
            get
            {
                return string.Format("{0}, {1}", AuthorLastName, AuthorFirstName);
            }
        }
    }

    public class AuthorMetadata
    {
        [Required(ErrorMessage="You must supply the author's first name"), Display(Name="First Name")]
        public string AuthorFirstName { get; set; }

        [Required(ErrorMessage = "You must supply the author's last name"), Display(Name = "Last Name")]
        public string AuthorLastName { get; set; }

    }
}
