using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSCrypto.Models
{
    public class JobViewModel
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-ZàáâäãåąčćđęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.-]+$", ErrorMessage = "The name field may only contain letters, spaces, hyphens, commas and dots")]
        [DataType(DataType.Text)]
        [Required]
        public String Name { get; set; }
    }
}
