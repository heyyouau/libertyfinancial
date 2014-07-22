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

        Genre GetGenre(int genreId);

        #endregion

        IQueryable<Publication> GetPublicationsByAuthorId(int authorId);
        IQueryable<Publication> GetPublicationsByAuthor(string authorName);
        IQueryable<Publication> GetPublicationsByGenre(List<int> genres);
        IQueryable<Genre> GetGenresByPublication(int publicationId);
        IQueryable<Author> GetAuthorsByPublication(int publicationId);

        void DeletePublicationAuthor(int authorId, int publicationId);
        

        void SavePublicationAuthor(int p1, int p2);

        void DeletePublicationGenre(int p1, int p2);

        void SavePublicationGenre(int p1, int p2);

        #region views

        IQueryable<MemberCurrentBookBorrowing> CurrentBookBorrowings { get; }
        IQueryable<BookBorrowingCount> BookBorrowingCount { get; }

        #endregion

        void BorrowBook(int memberId, int publicationId, DateTime eventDate, DateTime dueDate);

        IQueryable<Borrowing> GetBorrowings { get; }
    }
}
