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
    
    public partial class tblWithdrawal
    {
        public int withdrawalId { get; set; }
        public string branchName { get; set; }
        public Nullable<System.DateTime> transDate { get; set; }
        public string actNo { get; set; }
        public string actName { get; set; }
        public string actType { get; set; }
        public Nullable<decimal> chqNo { get; set; }
        public Nullable<System.DateTime> chqDate { get; set; }
        public Nullable<decimal> withAmount { get; set; }
        public string paidTo { get; set; }
        public Nullable<decimal> currentBalance { get; set; }
    }
}
