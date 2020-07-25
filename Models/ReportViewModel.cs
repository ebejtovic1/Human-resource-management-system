using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSCrypto.Models
{
    public class ReportViewModel
    {
        public int Id;
        public int JobId;
        public int DepartmentId;
        public string Name;
        public string LastName;
        public string Address;
        public float Salary;
        public DateTime CurrentDate = DateTime.Now;
    }
}
