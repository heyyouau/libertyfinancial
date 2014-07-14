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

        public List<Genre> SelectedGenres
        {
            get
            {
                if (_genres == null)
                {
                    foreach (var x in this.GenrePublications)
                    {
                        _genres.Add(x.Genre);
                    }
                }
                return _genres;
            }
            
        }
    }
}
