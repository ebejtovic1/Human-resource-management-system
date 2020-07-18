using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSCrypto.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
