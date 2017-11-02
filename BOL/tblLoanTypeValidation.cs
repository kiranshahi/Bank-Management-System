using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
   public class tblLoanTypeValidation
    {
        public string User { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Loan Type")]
        public string Loan_Type { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Interest Rate")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> Interest_Rate { get; set; }
    }

    [MetadataType(typeof(tblLoanTypeValidation))]
    public partial class tblLoanType
    {

    }
}
