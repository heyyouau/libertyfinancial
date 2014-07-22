using Liberty.Data.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Data
{
    [MetadataType(typeof(BorrowingMetadata))]
    public partial class Borrowing
    {
    }

    public class BorrowingMetadata
    {
        [Required(ErrorMessage="Please enter the due date"), NotBeforeTodayValidator("The due date must be after today")]
        public DateTime DueDate { get; set; }

        
    }


}
