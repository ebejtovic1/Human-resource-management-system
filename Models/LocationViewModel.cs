using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace HRMSCrypto.Models
{
    public class LocationViewModel
    {
        public int Id { get; set;}
        [Required]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z0-9àáâäãåąčćđęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.-]+$", ErrorMessage = "The address field may only contain letters, numbers, spaces, hyphens, commas and dots")]
        public String Address { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-ZàáâäãåąčćđęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.-]+$", ErrorMessage = "The city field may only contain letters, spaces, hyphens, commas and dots")]
        public String City { get; set; }

    

    }
}
