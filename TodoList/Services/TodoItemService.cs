using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Services {
    public class TodoItemService:ITodoItemService {
        private readonly ApplicationDbContext _context;
        //readonly的特性:http://www.360doc.com/content/18/0926/14/11935121_789834448.shtml
        public TodoItemService(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<TodoItem[]> GetIncompleteItemsAsync() {
            var items = await _context.Items.Where(x => x.IsDone == false).ToArrayAsync();
            /*创建一个匿名对象数组Items用于存储数据
            异步执行LINQ的查询语句,随后将查询的结果集用ToArray中线程安全的方法封装成一个数组
            因为是异步的,所以其中必须拥有一个await的关键字
            也可以直接返回结果*/
            return items;
        }

        public async Task<bool> AddItemAsync(TodoItem newItem) {
            newItem.Id=Guid.NewGuid();//这个类型可以直接获取一个不带重复的版本号
            newItem.DueAt = DateTimeOffset.Now.AddDays(5);//获取当前时间,随后加5
            newItem.IsDone = false;
            //对象初始化完成

            _context.Items.Add(newItem);
            /*数据库.表名.方法
             ApplicationDbContext:这个类型的对象与数据库链接之后,直接变成了一个数据库对象,可以直接调用,
             这可太牛逼了
            */
            var saveResult = await _context.SaveChangesAsync();//将up表中的数据上传,保存成功上传1
            return saveResult == 1;
        }
    }
}