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
        [RegularExpression(@"^[a-zA-ZàáâäãåąčćđęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$", ErrorMessage = "The name may only contain letters, apostrophes, spaces, hyphens, commas and dots")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-ZàáâäãåąčćđęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$", ErrorMessage = "The last name may only contain letters, apostrophes, spaces, hyphens, commas and dots")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9àáâäãåąčćđęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$", ErrorMessage = "The address may only contain numbers, letters, apostrophes, spaces, hyphens, commas and dots")]
        public String Address { get; set; }
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [RegularExpression("([0-9])+", ErrorMessage= "Phone number can only contain digits")]
        [Display(Name = "Phone number")]
        public String PhoneNumber { get; set; }

        [Display(Name = "End date")]
        public Nullable<DateTime> EndDate { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
 
        public Double Salary { get; set; }
        [RegularExpression("^[A-Za-z0-9]+", ErrorMessage = "This field can only contains digits and letters")]
        [Display(Name = "Bank account number")]
        [Required]
        public String BrojRacuna { get; set; }
        [Display(Name = "Job")]
        public int JobId { get; set; }
        public virtual JobViewModel Job { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public virtual DepartmentViewModel Department { get; set; }
    }
}
