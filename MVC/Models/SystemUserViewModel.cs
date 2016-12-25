using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class SystemUserViewModel
    {
        public string EditedBy { get; internal set; }
        [Display(Name ="E-mail")]
        public string Email { get; internal set; }
        [Display(Name = "Full Name")]
        public string FullName { get;  set; }
        public int Id { get; internal set; }
        public string Image { get; internal set; }
        public int Status { get; internal set; }
        [Display(Name = "Last Update")]
        public DateTime? UpdateDate { get; internal set; }
        public string UpdateDateString { get; internal set; }
        public int? UpdatedBy { get; internal set; }
    }
}