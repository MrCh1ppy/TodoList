using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Data {
    public class ApplicationDbContext : IdentityDbContext {
        //这里的引用类需要加上<ApplicationUser>的泛型,但是这会导致程序出错,无法新建
        //所以需要先删除,新建变更之后再添加
        //添加变更的语句为:dotnet ef migrations add "{变更文件名}"
        //如果出现没有工具的错误:如果是.net core3以上的就需要添加构建工具:dotnet tool install --global dotnet -ef
        //在变更完成之后需要更新数据库设计:dotnet database update
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }
        
        public DbSet<TodoItem> Items { get; set; }
        //代表会创建一个有关于Items的表单

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
        }
        //创建一个表单?
    }
}