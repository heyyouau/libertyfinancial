using Liberty.Data;
using Liberty.Data.Interfaces;
using Liberty.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Lib
{
    public class PublicationRepository : IPublicationRepository
    {
        IDataContext _dataContext;
        public PublicationRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Publication> GetPublications(IPublicationSearchParams searchParams)
        {
            var pubs = new List<Publication>();
            if (searchParams.AuthorId != 0)
                pubs = _dataContext.GetPublicationsByAuthorId(searchParams.AuthorId).ToList();
            else if (searchParams.GenreId.Count > 0)
            {
                pubs = _dataContext.GetPublicationsByGenre(searchParams.GenreId).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(searchParams.AuthorLastName))
            {
                pubs = _dataContext.GetPublicationsByAuthor(searchParams.AuthorLastName).ToList();
            }
            else
            {
                pubs = _dataContext.GetPublications().Where(e => (e.ISBN == searchParams.ISBN || string.IsNullOrWhiteSpace(searchParams.ISBN))
                                                                && (e.Title == searchParams.BookTitle || string.IsNullOrWhiteSpace(searchParams.BookTitle))).ToList();
            }


            pubs.ForEach(e => Hydrate(e));
            return pubs;
        }

        private void Hydrate(Publication p)
        {
            p.Genres = _dataContext.GetGenresByPublication(p.BookId).ToList();
            p.Authors = _dataContext.GetAuthorsByPublication(p.BookId).ToList();
        }

        public Publication GetPublication(int publicationId)
        {
            throw new NotImplementedException();
        }

        public Publication SavePublication(Data.Publication publication)
        {
            throw new NotImplementedException();
        }

        public List<Publication> GetPublicationsByAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public List<Genre> GetGenres()
        {
            return _dataContext.GetGenres().ToList();
        }

        public List<Author> GetAuthors()
        {
            return _dataContext.GetAuthors().ToList();
        }
    }
}
