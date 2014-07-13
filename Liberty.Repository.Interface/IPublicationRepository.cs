using Liberty.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Repository.Interface
{
    public interface IPublicationRepository
    {
        List<Publication> GetPublications(IPublicationSearchParams searchParams);

        Publication GetPublication(int publicationId);

        Publication SavePublication(Publication publication);

        List<Publication> GetPublicationsByAuthor(int authorId);


    }
}
