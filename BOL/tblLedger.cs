//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblLedger
    {
        public int ledgerId { get; set; }
        public string Account_Number { get; set; }
        public string Customer_Name { get; set; }
        public Nullable<System.DateTime> Transaction_Date { get; set; }
        public string Particulars { get; set; }
        public Nullable<decimal> Debit { get; set; }
        public Nullable<decimal> Credit { get; set; }
        public Nullable<decimal> Balance { get; set; }
    }
}
