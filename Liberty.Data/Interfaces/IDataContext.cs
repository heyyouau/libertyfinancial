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

        #endregion

        IQueryable<Publication> GetPublicationsByAuthorId(int authorId);
        IQueryable<Publication> GetPublicationsByAuthor(string authorName);
        IQueryable<Author> GetAuthorsByPublication(int publicationId);
        IQueryable<MemberCurrentBookBorrowingsWithName> GetMemberBorrowings { get; }
        void DeletePublicationAuthor(int authorId, int publicationId);
        void SavePublicationAuthor(int p1, int p2);

        #region views
        IQueryable<MemberCurrentBookBorrowing> CurrentBookBorrowings { get; }
        IQueryable<BookBorrowingCount> BookBorrowingCount { get; }
        void BorrowBook(int memberId, int publicationId, DateTime eventDate, DateTime dueDate);
        IQueryable<Borrowing> GetBorrowings { get; }
        #endregion
    }
}
