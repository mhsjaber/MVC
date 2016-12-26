using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class DesignationsViewModel
    {
        [Display(Name = "Created By")]
        public string CreatedBy { get; internal set; }
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public int Status { get; internal set; }
        [Display(Name="Last Update")]
        public DateTime? UpdateDate { get; internal set; }
    }
}