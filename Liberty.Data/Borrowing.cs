using Liberty.Data.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Data
{
    [MetadataType(typeof(BorrowingMetadata))]
    public class Borrowing
    {
        public int BorrowingId { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnedDate { get; set; }
        public bool Returned { get; set; }
    }

    public class BorrowingMetadata
    {
        
        public BorrowingMetadata()
        {

        }

        [Required(ErrorMessage = "Please enter the due date"), NotBeforeTodayValidator("The due date must be after today"), DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}" , ApplyFormatInEditMode=true)]
        public DateTime DueDate { get; set; }
        
    }


}
