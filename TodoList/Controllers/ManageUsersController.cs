using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Controllers {
    [Authorize(Roles = "Administrator")]
    /*提供了访问的权限设置*/
    public class ManageUsersController : Controller {
        private readonly UserManager<IdentityUser> _userManager;

        public ManageUsersController(UserManager<IdentityUser> userManager) {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index() {
            /*从数据集中获取目标,这个UserManager貌似自带一个数据库来存放账号*/
            var admin = (await _userManager.GetUsersInRoleAsync("Administrator")).ToArray();

            var everyOne = await _userManager.Users.ToArrayAsync();

            var model = new ManageUsersViewModel {
                Administrators = admin,
                Everyone = everyOne
            };
            return RedirectToAction("Index");
            /*有修改,可能有问题*/
        }

    }
}