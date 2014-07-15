using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Data
{
    public partial class Publication
    {

        private List<Genre> _genres = new List<Genre>(); 

        public List<Genre> Genres
        {
            get
            {
                return _genres;
            }
            set
            {
                _genres = value;

            }
            
        }

        private List<Author> _authors = new List<Author>();

        public List<Author> Authors
        {
            get
            {
                return _authors;
            }
            set
            {
                _authors = value;
            }
        }
    }
}
