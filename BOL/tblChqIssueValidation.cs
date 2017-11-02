using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
   public class tblChqIssueValidation
    {
        [Required(ErrorMessage ="This Field Is Required"),Display(Name ="Account Number")]
        public string actNo { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Account Name")]
        public string custName { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Number Of Leaves")]
        public Nullable<decimal> noOfLeaves { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Cheque Start Number")]
        public Nullable<decimal> chqStartNo { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Cheque End Number")]
        public Nullable<decimal> chqEndNo { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Cheque Issued By")]
        public string chqIssuedBy { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Issued Date")]
        public Nullable<System.DateTime> issuedDate { get; set; }
    }
    [MetadataType(typeof(tblChqIssueValidation))]
    public partial class tblChqIssue
    {

    }
}
