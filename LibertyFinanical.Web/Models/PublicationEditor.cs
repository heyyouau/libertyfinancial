using Liberty.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibertyFinancial.Web.Models
{
    public class PublicationEditor
    {
        private List<Genre> _genres;

        public PublicationEditor(Publication publication, List<Genre> genres)
        {
            Publication = publication;
            _genres = genres;

        }

        public Publication Publication { get; set; }

        private List<SelectListItem> _selectList;

        public List<SelectListItem> GenreList 
        {
            get
            {
                if (_selectList == null)
                {

                    foreach (var genre in _genres)
                    {
                        
                        _selectList.Add(new SelectListItem() { Value = genre.Id.ToString(), Text = genre.GenreName, Selected = Publication.SelectedGenres.Any(e => e.Id == genre.Id) });
                    }
                }
                return _selectList;
            }
        }

    }
}