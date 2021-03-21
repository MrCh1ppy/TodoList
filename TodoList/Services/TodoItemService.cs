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

        public async Task<TodoItem[]> GetIncompleteItemsAsync(ApplicationUser user) {
            var items = await _context.Items.Where(x => x.IsDone == false&&x.UserId==user.Id).ToArrayAsync();
            /*创建一个匿名对象数组Items用于存储数据
            异步执行LINQ的查询语句,随后将查询的结果集用ToArray中线程安全的方法封装成一个数组
            因为是异步的,所以其中必须拥有一个await的关键字
            也可以直接返回结果
            
            对于已经做完的事情将会被设置为不可见*/
            return items;
        }

        public async Task<bool> AddItemAsync(TodoItem newItem,ApplicationUser user) {
            newItem.Id=Guid.NewGuid();//这个类型可以直接获取一个不带重复的版本号
            newItem.DueAt = DateTimeOffset.Now.AddDays(5);//获取当前时间,随后加5
            newItem.IsDone = false;
            newItem.UserId = user.Id;
            //对象初始化完成

            _context.Items.Add(newItem);
            /*数据库.表名.方法
             ApplicationDbContext:这个类型的对象与数据库链接之后,直接变成了一个数据库对象,可以直接调用,
             这可太牛逼了
            */
            var saveResult = await _context.SaveChangesAsync();//将up表中的数据上传,保存成功上传1
            return saveResult == 1;
        }

        public async Task<bool> MarkDoneAsync(Guid id,ApplicationUser user) {
            /*在数据库中LINQ进行查找,获取结果集*/
            var item = await _context.Items
                .Where(x => x.Id == id&&x.UserId==user.Id)
                .SingleOrDefaultAsync();
            /*如果没找到则返回false*/
            if (null == item) {
                return false;
            }
            /*找到后进行处理*/
            /*不在数据库中删除做完的东西,而是将其设置为不可见*/
            item.IsDone = true;
            var saveResult = await _context.SaveChangesAsync();
            return 1 == saveResult;
        }
    }
}