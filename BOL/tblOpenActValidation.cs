using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class tblOpenActValidation
    {
        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Branch Name")]
        public string branchName { get; set; }

        //[Required(ErrorMessage = "This Field Is Required")]
        [Display(Name = "Account Type")]
        public string actType { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Account Created By")]
        public string actApprovedBy { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Customer Name")]
        public string custName { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DOB { get; set; }

        //[Required(ErrorMessage = "This Field Is Required")]
        [Display(Name = "Opening Date")]
        public Nullable<System.DateTime> openingDate { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Account Number")]
        public string acctNo { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Opening Balance")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> openingBalance { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Current Balance")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> currentBalance { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Nominee Name")]
        public string nomineeName { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Nominee Relation")]
        public string nomineeRelation { get; set; }
    }

    [MetadataType(typeof(tblOpenActValidation))]
    public partial class tblOpenAct
    {

    }
}
