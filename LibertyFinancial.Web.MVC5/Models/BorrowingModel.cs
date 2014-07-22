using Liberty.Data;
using Liberty.Data.Validators;
using Liberty.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibertyFinancial.Web.MVC5.Models
{
    public class BorrowingModel : IBorrowingModel
    {
        //required by MVC
        public BorrowingModel()
        {

        }
        public BorrowingModel(Member member)
        {
            Member = member;
        }

        public BorrowingModel(Member m, List<MemberCurrentBookBorrowing> currentBooks)
        {
            Member = m;
            MemberCurrentBookBorrowing = currentBooks;
        }

        public BorrowingModel(Member m, Publication publciation)
        {
            Member = m;
            Publication = publciation;
        }

        public Member Member { get; set; }

        public List<MemberCurrentBookBorrowing> MemberCurrentBookBorrowing { get; set; }

        public Publication Publication { get; set; }

        //public Borrowing BorrowingInformation { get; set; }
        [NotBeforeTodayValidator("Please enter a data that is not before today's date")]
        public DateTime DueDate{ get; set; }

        public BookEventType EventType { get; set; }
    }

    
}