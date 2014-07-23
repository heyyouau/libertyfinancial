using Liberty.Data;
using Liberty.Data.Interfaces;
using Liberty.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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
            else if (!string.IsNullOrWhiteSpace(searchParams.AuthorLastName))
            {
                pubs = _dataContext.GetPublicationsByAuthor(searchParams.AuthorLastName).ToList();
            }
            else
            {
                pubs = _dataContext.GetPublications().Where(e => (e.ISBN == searchParams.ISBN || string.IsNullOrWhiteSpace(searchParams.ISBN))
                                                                && (e.Title == searchParams.BookTitle || string.IsNullOrWhiteSpace(searchParams.BookTitle))).ToList();
            }


            //pubs.ForEach(e => Hydrate(e));
            return pubs;
        }

       

        public Publication SavePublication(Publication publication)
        {

            using (var t = new TransactionScope())
            {
                try
                {
                    var newPub = _dataContext.SavePublication(publication);
                    _dataContext.SaveChanges();
                    t.Complete();
                    return newPub;
                }
                catch (Exception ex)
                {    
                    throw ex;
                }
            }
            
        }


        public Publication GetPublication(int publicationId)
        {
            return _dataContext.GetPublication(publicationId);
        }

        public List<Publication> GetPublicationsByAuthor(int authorId)
        {
            return _dataContext.GetPublicationsByAuthorId(authorId).ToList();
        }

        

        public List<Author> GetAuthors()
        {
            return _dataContext.GetAuthors().ToList();
        }
    }
}
