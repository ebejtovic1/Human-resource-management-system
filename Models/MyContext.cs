using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSCrypto.Models
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeViewModel>().ToTable("Employee");
            modelBuilder.Entity<JobViewModel>().ToTable("Job");
            modelBuilder.Entity<DepartmentViewModel>().ToTable("Department");
            modelBuilder.Entity<LocationViewModel>().ToTable("Location");


        }
    }
}
