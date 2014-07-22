using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Data
{
    public partial class Member
    {
        public int AvailableBorrows
        {
            get
            {
                return this.MaxBorrowings - Borrowings.Count;
            }
        }
    }
}
