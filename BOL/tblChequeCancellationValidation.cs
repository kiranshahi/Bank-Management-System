using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
   public class tblChequeCancellationValidation
    {

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Account Number")]
        public string acctNo { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Account Name")]
        public string custName { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Cheque Number")]
        public Nullable<decimal> chqNo { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name ="Cancellation Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> cancellationDate { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        public string Reason { get; set; }
    }
    [MetadataType(typeof(tblChequeCancellationValidation))]
    public partial class tblChqCancellation
    {

    }
}
