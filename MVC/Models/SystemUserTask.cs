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
    
    public partial class SystemUserTask
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public int UpdatedBy { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public int Status { get; set; }
    
        public virtual SystemTask SystemTask { get; set; }
        public virtual SystemUser SystemUser { get; set; }
        public virtual SystemUser SystemUser1 { get; set; }
        public virtual SystemUser SystemUser2 { get; set; }
    }
}
