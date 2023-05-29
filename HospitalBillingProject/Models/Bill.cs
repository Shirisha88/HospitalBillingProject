//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalBillingProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bill
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public Nullable<System.DateTime> BillDate { get; set; }
        public string ItemName { get; set; }
        public Nullable<double> TotalAmount { get; set; }
        public Nullable<double> AmountPaid { get; set; }
        public Nullable<double> Balance { get; set; }
        public Nullable<int> patientid { get; set; }
    
        public virtual Patient Patient { get; set; }
    }
}
