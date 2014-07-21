using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Data
{
    public partial class GenrePublication
    {
        public bool Delete { get; set; }

        public string GenreName
        {
            get
            {
                return this.Genre.GenreName;
            }
        }
    }
}
