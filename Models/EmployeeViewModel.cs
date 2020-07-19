using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSCrypto.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last name")]
        public string LastName { get; set;  }
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        public String Address { get; set; }
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Phone number")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public String PhoneNumber { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
 
        public Double Salary { get; set; }
        [Display(Name = "Bank account number")]
        public String BrojRacuna { get; set; }
        [Display(Name = "Job")]
        public int JobId { get; set; }
        public virtual JobViewModel Job { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public virtual DepartmentViewModel Department { get; set; }
    }
}
