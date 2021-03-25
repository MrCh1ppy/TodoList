using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Services;

namespace TodoList.Controllers {
    /*这个属性要求用户在执行操作之前需要登陆过
     在没登录时定位到Todo会自动定向到登录界面*/
    
    [Authorize]
    public class TodoController : Controller {

        private readonly ITodoItemService _todoItemService;
        private readonly UserManager<IdentityUser> _userManager;
        /*Application需要自己另外继承IdentityUser类在模型文件夹新建一个*/
        /*ApplicationUser使这个控制器无法被激活*/
        /*解决方法:直接将Application用IdentityUser代替*/

        public TodoController(ITodoItemService todoItemService,UserManager<IdentityUser> userManager) {
            _todoItemService = todoItemService;
            _userManager = userManager;
        }
        /*依赖注入的意思大概就是框架帮你创建吧*/

        public async Task<IActionResult> Index() {
            var currentUser = await _userManager.GetUserAsync(User);
            /*.GetUserAsync方法可以直接从属性"User"中获取当前的用户的一些信息,然后依据这些信息,在数据库中查到这个用户的信息
             User:用于存储当前网页上用户的信息
             */
            if (null == currentUser) {
                return Challenge();
                /*Challenge:重新登录*/
            }
            /*这个IActionResult到底啥玩意儿*/
            var items = await _todoItemService.GetIncompleteItemsAsync(currentUser);
            /*这里通过从接口那里获取的方法来对于数据库进行操作,获取结果集*/
            var model = new TodoViewModel() 
            {
                Items = items
                //必须使用这种方法来定义? 
                //像是一个构造函数
            };
            /*通过接口方法获取了一个事务的列表,接着依此创建了一个ModelView的视图模型
            接着通过返回View包装的模型,返回一个页面,进而进行实现*/
            return View(model);
        }

        [ValidateAntiForgeryToken]
        /*用于防止跨站请求伪造,即保证我的链接跳转到的是我的程序*/
        public async Task<IActionResult> AddItem(TodoItem newItem) {
            if (!ModelState.IsValid) {
                /*ModelState为"模型核验"的结果,core会通过开发者设定的规则对输入字符串进行检验
                 TodoItem上Title字段上方的[Required]即代表一个检验标准,相当于"not null"
                 习惯上,先核验再操作*/
                //valid:非法
                return RedirectToAction("Index");//如果核验不通过则重定向回去
            }

            var currentUser = await _userManager.GetUserAsync(User);
            var successful = await _todoItemService.AddItemAsync(newItem,currentUser);
            /*就是获取用户名之后将其加入方法之中*/

            if (!successful) {
                return BadRequest("can't add it");
                //跳转到400 error page
            }

            return RedirectToAction("Index");
        }

        /*用控制器调用多重封装过的方法,检验,逻辑,调用不放在同一层
         IAction大概代表下一个对于页面的跳转操作
         结构类似于上一个,都是标准版的包装方法*/
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id) {
            if (id == Guid.Empty) {
                return RedirectToAction("Index");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            var successful = await _todoItemService.MarkDoneAsync(id,user:currentUser);
            
            if (!successful) {
                return BadRequest("悲");
            }

            return RedirectToAction("Index");
        }
    }
}