using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class EmployeesViewModel
    {
        public string Address { get; internal set; }
        public string Designation { get; internal set; }
        public string Email { get; internal set; }
        [Display(Name ="Type")]
        public string EmployeeType { get; internal set; }
        [Display(Name = "First Name")]
        public string FirstName { get; internal set; }
        public int Id { get; internal set; }
        public string Image { get; internal set; }
        [Display(Name = "Last name")]
        public string LastName { get; internal set; }
        public string Mobile { get; internal set; }
        public int Status { get; internal set; }
    }
}