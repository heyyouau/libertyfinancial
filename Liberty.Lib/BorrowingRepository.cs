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

        public List<MemberCurrentBookBorrowing> GetCurrentBookBorrowings(int memberId)
        {
            return _datacontext.CurrentBookBorrowings.Where(e => e.MemberId == memberId).ToList();
        }

        public void BorrowBook(IBorrowingModel borrowingModel)
        {
            _datacontext.BorrowBook(borrowingModel.Member.MemberId, borrowingModel.Publication.BookId, DateTime.Now, borrowingModel.DueDate);
        }

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

        public BookBorrowingCount GetPublicationStatus(int publicationId)
        {
            return _datacontext.BookBorrowingCount.FirstOrDefault(e => e.BookId == publicationId);
        }
    }
}
