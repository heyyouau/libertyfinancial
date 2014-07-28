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


        /// <summary>
        /// return all publications or publications that match the search parameters
        /// </summary>
        /// <param name="searchParams">the parameters to execute the search on</param>
        /// <returns>a matching list of publications</returns>
        public List<Publication> GetPublications(IPublicationSearchParams searchParams)
        {
            var pubs = new List<Publication>();
            if (!string.IsNullOrWhiteSpace(searchParams.AuthorLastName))
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

       
        /// <summary>
        /// save the publication
        /// </summary>
        /// <param name="publication">The publication  to be saved</param>
        /// <returns>the saved publication</returns>
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

        /// <summary>
        /// return the publication based on this key
        /// </summary>
        /// <param name="publicationId">the database id of the publication to be returned</param>
        /// <returns>The matching publication</returns>
        public Publication GetPublication(int publicationId)
        {
            return _dataContext.GetPublication(publicationId);
        }


        ///// <summary>
        ///// find all publications with the suppied author id
        ///// </summary>
        ///// <param name="authorId">the database id of the author</param>
        ///// <returns>A list of publications for this author</returns>
        //public List<Publication> GetPublicationsByAuthor(int authorId)
        //{
        //    return _dataContext.GetPublicationsByAuthorId(authorId).ToList();
        //}

        
    }
}
