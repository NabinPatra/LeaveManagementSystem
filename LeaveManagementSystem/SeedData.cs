using LeaveManagementSystem.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementSystem
{
    public static class SeedData
    {
        public static void Seed(UserManager<Employee> userManager,
                              RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<Employee> userManager)
                              
        {
            if (userManager.FindByNameAsync("manager").Result == null)
            {
                var user = new Employee
                {
                    UserName = "manager@gmail.com",
                    Email = "manager@gmail.com"
                };

                var result = userManager.CreateAsync(user, "Manager24@").Result;
                if(result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }

        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)

        {
            if(!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };
                
                roleManager.CreateAsync(role);
            }

            if (!roleManager.RoleExistsAsync("Employee").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Employee"
                };

                roleManager.CreateAsync(role);
            }
        }




    }
}
