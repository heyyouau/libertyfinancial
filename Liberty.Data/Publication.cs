using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Data
{
    public partial class Publication
    {
        public BookBorrowingCount BookBorrowing { get; set; }
       


        public bool AvailableForLoan
        {
            get
            {
                return BookBorrowing == null? false : BookBorrowing.Available > 0;
            }
        }
    }
}
