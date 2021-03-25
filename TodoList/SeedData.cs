using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

/*待Review*/
namespace TodoList {
    public class SeedData {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            await EnsureRolesAsync(roleManager);

            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            await EnsureTestAdminAsync(userManager);
        }

        private static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager) {
            /*RoleManager是干嘛的
             这里好像就是为了这玩意儿添加了一个字符串,保证有了一个角色?
             角色管理器,当然是管理角色的,这里有俩角色:Admin与everyOne*/
            var alreadyExists = await roleManager.RoleExistsAsync(Constant.AdministrationRole);
            if (alreadyExists) {
                return;
            }

            await roleManager.CreateAsync(new IdentityRole(Constant.AdministrationRole));
        }

        /*这个应该是寻找管理员账号,如果没有的话添加上去*/
        private static async Task EnsureTestAdminAsync(UserManager<IdentityUser> userManager) {
            var testAdmin = await userManager.Users.Where(x => x.UserName == "admin@todo.local").SingleOrDefaultAsync();

            if (testAdmin != null) {
                return;
            }

            testAdmin = new IdentityUser() {
                UserName = "admin@todo.local",
                Email = "admin@todo.local"
            };

            await userManager.CreateAsync(testAdmin,"NotSecure123!!");
            await userManager.AddToRoleAsync(testAdmin, Constant.AdministrationRole);
        }
    }
}