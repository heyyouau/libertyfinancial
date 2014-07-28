using Liberty.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Repository.Interface
{
    public interface IBorrowerRepository
    {
        List<MemberCurrentBookBorrowing> GetCurrentBookBorrowings(int memberId);

        void BorrowBook(IBorrowingModel borrowingModel);

        void ReturnBook(int borrowingId, DateTime dateTime);
    }
}
