using Liberty.Data.Interfaces;
using Liberty.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Lib
{
    public class ReportsRepository:IReportsRepository
    {
        private IDataContext _dataContext;
        public ReportsRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Data.MemberCurrentBookBorrowing> GetOverDueBooks(int daysOverDue)
        {
            return _dataContext.CurrentBookBorrowings.Where(e => e.DueDate < DateTime.Today.AddDays(-daysOverDue)).ToList();
        }
    }
}
