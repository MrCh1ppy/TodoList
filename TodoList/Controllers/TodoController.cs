using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Services;

namespace TodoList.Controllers {
    public class TodoController : Controller {

        private readonly ITodoItemService _todoItemService;

        public TodoController(ITodoItemService todoItemService) {
            _todoItemService = todoItemService;
        }
        // GET
        public async Task<IActionResult> Index() {
            /*这个IActionResult到底啥玩意儿*/
            var items = await _todoItemService.GetIncompleteItemsAsync();
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

            var successful = await _todoItemService.AddItemAsync(newItem);

            if (!successful) {
                return BadRequest("can't add it");
                //跳转到400 error page
            }

            return RedirectToAction("Index");
        }
    }
}