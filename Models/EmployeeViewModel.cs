using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSCrypto.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set;  }
        public DateTime DateOfBirth { get; set; }
        public String Address { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public String Email { get; set; }
        public Double Salary { get; set; }
        public String BrojRacuna { get; set; }
        //job
        //department

    }
}
