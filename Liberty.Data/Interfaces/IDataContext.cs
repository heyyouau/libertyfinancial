using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Data.Interfaces
{
    public interface IDataContext
    {

        void SaveChanges();

        IQueryable<Author> GetAuthors();

        Author GetAuthor(int authorId);

        Author SaveAuthor(Author author);

        #region Members

        IQueryable<Member> GetMembers();


        Member GetMember(int memberId);

        Member SaveMember(Member member);

        #endregion

        #region publications

        //get publication
        Publication GetPublication(int publicationId);

        //save publication
        Publication SavePublication(Publication publication);

        //get publications
        IQueryable<Publication> GetPublications();

        IQueryable<Genre> GetGenres();



        #endregion

        IQueryable<Publication> GetPublicationsByAuthorId(int authorId);
        IQueryable<Publication> GetPublicationsByAuthor(string authorName);
        IQueryable<Publication> GetPublicationsByGenre(List<int> genres);
        IQueryable<Genre> GetGenresByPublication(int publicationId);
        IQueryable<Author> GetAuthorsByPublication(int publicationId);
    }
}
