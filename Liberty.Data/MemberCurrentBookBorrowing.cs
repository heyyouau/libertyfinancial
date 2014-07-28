using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Data
{
    public class MemberCurrentBookBorrowing
    {
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string AuthorFullName { get; set; }
        public int MemberId { get; set; }
        public int BorrowingId { get; set; }

    }
}
