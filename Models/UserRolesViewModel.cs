using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSCrypto.Models
{
    public class UserRolesViewModel
    {
        public string RoleId { get; set; }
        [Display(Name = "Role name")]
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
}
