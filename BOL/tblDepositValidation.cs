using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
   public class tblDepositValidation
    {
        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Branch Name")]
        public string branchName { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Transaction Date")]
        public Nullable<System.DateTime> transactionDate { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Account Number")]
        public string acctNo { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Account Name")]
        public string actName { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Account Type")]
        public string actType { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Deposit Amount")]
        public Nullable<decimal> depositAmount { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        public string Depositer { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Current Balance")]
        public Nullable<decimal> currentBalance { get; set; }

       }

    [MetadataType(typeof(tblDepositValidation))]
    public partial class tblDeposit
    {

    }
}

