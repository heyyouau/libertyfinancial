using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Data
{
    public class BookBorrowingCount
    {
        public int Copies { get; set; }
        public bool borrowed { get; set; }
        public int Available { get; set; }
        public int BookId { get; set; }

    }
}
