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
    public class BorrowingRepository:IBorrowerRepository
    {
        private IDataContext _datacontext;

        public BorrowingRepository(IDataContext dataContext)
        {
            _datacontext = dataContext;
        }


        /// <summary>
        /// return a list of which books this member currently has unreturned
        /// </summary>
        /// <param name="memberId">the id of member who was borrowed the books</param>
        /// <returns></returns>
        public List<MemberCurrentBookBorrowing> GetCurrentBookBorrowings(int memberId)
        {
            return _datacontext.CurrentBookBorrowings.Where(e => e.MemberId == memberId).ToList();
        }


        /// <summary>
        /// Borrow a single publication for a single member
        /// </summary>
        /// <param name="borrowingModel"></param>
        public void BorrowBook(IBorrowingModel borrowingModel)
        {
            _datacontext.BorrowBook(borrowingModel.Member.MemberId, borrowingModel.Publication.BookId, DateTime.Now, borrowingModel.DueDate);
        }


        /// <summary>
        /// mark this book as returned
        /// </summary>
        /// <param name="borrowingId">the database id of the borrowing event</param>
        /// <param name="returndate">the date that the book has been returned</param>
        public void ReturnBook(int borrowingId, DateTime returndate)
        {
            var b = _datacontext.GetBorrowings.FirstOrDefault(e => e.BorrowingId == borrowingId);
            if (b != null)
            {
                b.ReturnedDate = returndate;
                b.Returned = true;
                //_datacontext.SaveBorrowing(b);
            }

        }

    }
}
