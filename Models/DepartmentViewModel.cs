using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSCrypto.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z0-9àáâäãåąčćđęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$", ErrorMessage = "The name field may only contain letters, apostrophes, numbers, spaces, hyphens, commas and dots")]
        public String Name { get; set; }
        [Display(Name = "Location")]
        public int LocationId { get; set; }
        public virtual LocationViewModel Location { get; set; }
    }
}
