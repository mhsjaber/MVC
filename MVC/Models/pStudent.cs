using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    [MetadataType(typeof(ViewDepartment))]
    public partial class Department
    {

    }

    public class ViewDepartment
    {
        [Display(Name = "Department")]
        public string DepartName { set; get; }
    }

    [MetadataType(typeof(ViewStudent))]
    public partial class Student
    {

    }

    public class ViewStudent
    {
        [Display(Name = "Department")]
        public int DepartmentId { set; get; }
        [Required]
        public string Name;
    }
}