using LeaveManagementSystem.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementSystem
{
    public static class Roles
    {
        public static void Get(UserManager<Employee> userManager,
                              RoleManager<IdentityRole> roleManager)
        {
            GetRoles(roleManager);
            GetUsers(userManager);
        }

        private static void GetUsers(UserManager<Employee> userManager)
                              
        {
            if (userManager.FindByNameAsync("manager@gmail.com").Result == null)
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

        private static void GetRoles(RoleManager<IdentityRole> roleManager)

        {
            if(!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };
                
                var result = roleManager.CreateAsync(role);
            }

            if (!roleManager.RoleExistsAsync("Employee").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Employee"
                };

                var result = roleManager.CreateAsync(role);
            }
        }




    }
}
