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
    
    public partial class EmpDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> DoB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string BloodGroup { get; set; }
        public string EmployeeType { get; set; }
        public Nullable<System.DateTime> JoinDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public int Status { get; set; }
        public int DesignationId { get; set; }
    
        public virtual EmpDesignation EmpDesignation { get; set; }
        public virtual SystemUser SystemUser { get; set; }
        public virtual SystemUser SystemUser1 { get; set; }
    }
}
