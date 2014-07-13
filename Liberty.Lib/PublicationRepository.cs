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
            throw new NotImplementedException();
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
    }
}
