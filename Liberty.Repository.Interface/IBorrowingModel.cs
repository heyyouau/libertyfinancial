using Liberty.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Repository.Interface
{
    public interface IBorrowingModel
    {
        Member Member { get; set; }

        List<MemberCurrentBookBorrowing> MemberCurrentBookBorrowing { get; set; }

        Publication Publication { get; set; }

        Borrowing BorrowingInformation { get; set; }

        BookEventType EventType { get; set; }
    }

    public enum BookEventType
    {
        Borrow,
        Return
    }
}
