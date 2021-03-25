using Microsoft.AspNetCore.Identity;

namespace TodoList.Models {
    public class ManageUsersViewModel {
        /*创建一个模型用于显示*/
        public IdentityUser[] Administrators { get; set; }
        public IdentityUser[] Everyone { get; set; }
    }
}