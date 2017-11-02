using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class tblLoanValidation
    {

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Account Number")]
        public string actNo { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Customer Name")]
        public string cust_Name { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Monthly Income")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> Monthly_Income { get; set; }
        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Loan Amount")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> Loan_Amount { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Loan Type")]
        public Nullable<decimal> Loan_Type { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Interest Rate")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> Interest_Rate { get; set; }      

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Loan Tenure(Years)")]
        public Nullable<decimal> Loan_Tenure_Years_ { get; set; }
      
        [Required(ErrorMessage = "This Field Is Required")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> Interest { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Annual Interest")]
        public Nullable<decimal> YearlyInterest { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Monthly Interest")]
        public Nullable<decimal> MonthlyInterest { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Issued Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Issued_Date { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Mortgage Details")]
        public string Mortgage_Details { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Guarenteer's Name")]
        public string Guarenteer_Name { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Guarenteer's Address")]
        public string Address_Guarenteer_ { get; set; }

        [Required(ErrorMessage = "This Field Is Required"), Display(Name = "Contact Number")]
        [DataType(DataType.Currency)]
        public string Contact_Number { get; set; }

    }
    [MetadataType(typeof(tblLoanValidation))]
    public partial class tblLoan
    {

    }
}

