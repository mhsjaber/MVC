using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class FabricDetailsViewModel
    {
        public DateTime CreateDate { get; internal set; }
        public string Description { get; internal set; }
        [Display(Name ="Updated By")]
        public string EditedBy { get; internal set; }
        [Display(Name = "Code")]
        public string FabricCode { get; internal set; }
        [Display(Name = "Fabric Name")]
        public string FabricName { get; internal set; }
        public int Id { get; internal set; }
        public int Status { get; internal set; }
        public int? UpdatedBy { get; internal set; }
    }
}