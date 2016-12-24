using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    [MetadataType(typeof(SystemUserMetaData))]
    public partial class SystemUser
    {

    }

    public class SystemUserMetaData
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Last Update")]
        public DateTime? UpdateDate { get; set; }
    }
}