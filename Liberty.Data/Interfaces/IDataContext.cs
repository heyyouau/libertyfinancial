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

        List<Author> GetAuthors();

        Author GetAuthor(int authorId);

        Author SaveAuthor(Author author);

        #region Members

        List<Member> GetMembers();


        Member GetMember(int memberId);

        Member SaveMember(Member member);

        #endregion

        #region publications

        //get publication
        Publication GetPublication(int publicationId);

        //save publication
        Publication SavePublication(Publication publication);

        //get publications
        List<Publication> GetPublications();

        #endregion

        List<Publication> GetPublicationsByAuthorId(int authorId);
        List<Publication> GetPublicationsByAuthor(string authorName);
        List<Author> GetAuthorsByPublication(int publicationId);
        List<MemberCurrentBookBorrowingsWithName> GetMemberBorrowings { get; }
        void DeletePublicationAuthor(int authorId, int publicationId);
        void SavePublicationAuthor(int p1, int p2);

        #region views
        List<MemberCurrentBookBorrowing> CurrentBookBorrowings { get; }
        List<BookBorrowingCount> BookBorrowingCount { get; }
        void BorrowBook(int memberId, int publicationId, DateTime eventDate, DateTime dueDate);
        List<Borrowing> GetBorrowings { get; }
        #endregion
    }
}
