using Liberty.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Repository.Interface
{
    public interface IReportsRepository
    {
        List<MemberCurrentBookBorrowingsWithName> GetOverDueBooks(int daysOverDue);
    }
}
