using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;

namespace TodoList.Services {
    public interface ITodoItemService {
        Task<TodoItem[]> GetIncompleteItemsAsync(IdentityUser user);
        Task<bool> AddItemAsync(TodoItem newItem,IdentityUser user);
        /*对于task的探究:
         代表一种异步的方法封装,
         如果返回值为Void:那么就单纯返回 Task
         如果返回值为确定的值:那么就返回 Task<需要返回对象的类型>
         */
        Task<bool> MarkDoneAsync(Guid id,IdentityUser user);
    }
}