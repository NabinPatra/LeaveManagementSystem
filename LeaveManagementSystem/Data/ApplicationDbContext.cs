using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Models;

namespace LeaveManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        public object LeaveAllocation { get; internal set; }
        public DbSet<LeaveManagementSystem.Models.LeaveTypeVM> DetailsLeaveTypeVM { get; set; }
        public DbSet<LeaveManagementSystem.Models.EmployeeVM> EmployeeVM { get; set; }
        public DbSet<LeaveManagementSystem.Models.LeaveRequestVM> LeaveRequestVM { get; set; }
    }
}
