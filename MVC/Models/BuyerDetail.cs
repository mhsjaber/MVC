//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BuyerDetail
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyDetails { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonMobile { get; set; }
        public string ContactPersonDetails { get; set; }
        public string Mobile { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public int Status { get; set; }
    
        public virtual SystemUser SystemUser { get; set; }
    }
}
