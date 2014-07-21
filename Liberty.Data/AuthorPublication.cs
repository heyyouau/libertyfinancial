using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Data
{
    public partial class AuthorPublication
    {
        public bool Delete { get; set; }
        public string AuthorFullName 
        { 
            get 
            {
                return this.Author.AuthorFullName;
            } 
       }
    }
}
