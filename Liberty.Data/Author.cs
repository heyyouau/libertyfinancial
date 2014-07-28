using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Data
{
    [MetadataType(typeof(AuthorMetadata))]
    public class Author
    {


        public int AuthorId{ get; set; }

        private string _authorFirstName;

        [Required(ErrorMessage = "Please enter the first name")]
        public string AuthorFirstName 
        { 
            get {
                return string.IsNullOrEmpty(_authorFirstName) ? string.Empty : _authorFirstName;
            }
            set
            {
                _authorFirstName = value;
            }
        }

        [Required(ErrorMessage = "Please enter the last name")]
        public string AuthorLastName { get; set; }
        public string Notes { get; set; }

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
