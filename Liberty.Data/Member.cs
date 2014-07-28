using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Data
{
    public class Member
    {

        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MaxBorrowings { get; set; }
        public string ContactNumber { get; set; }

        private List<Borrowing> _borrowings = new List<Borrowing>();

        public List<Borrowing> Borrowings
        {
            get
            {
                return _borrowings;
            }
        }

        public int AvailableBorrows
        {
            get
            {
                return this.MaxBorrowings - Borrowings.Count;
            }
        }
    }
}
