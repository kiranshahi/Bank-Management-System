using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
   public class tblWithdrawalValidation
    {
        
        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Branch Name")]
        public string branchName { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Transaction Date")]
        public Nullable<System.DateTime> transDate { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Account Number")]
        public string actNo { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Account Name")]
        public string actName { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Account Type")]
        public string actType { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Cheque Number")]
        public Nullable<decimal> chqNo { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Cheque Date")]
        public Nullable<System.DateTime> chqDate { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Withdrawal Amount")]
        public Nullable<decimal> withAmount { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Paid To")]
        public string paidTo { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Current Balance")]
        public Nullable<decimal> currentBalance { get; set; }

    }

    [MetadataType(typeof(tblWithdrawalValidation))]
    public partial class tblWithdrawal
    {

    }
}
