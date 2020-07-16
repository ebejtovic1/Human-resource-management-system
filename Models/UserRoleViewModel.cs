using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSCrypto.ViewModels
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }
        [Display(Name = "Username")]
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
    }
}
