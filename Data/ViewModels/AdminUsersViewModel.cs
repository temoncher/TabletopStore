using System.Collections.Generic;
using TabletopStore.Models.Roles;

namespace TabletopStore.Data.ViewModels
{
    public class AdminUsersViewModel
    {
        public List<User> Users { get; set; }
        public User SelectedUser { get; set; }
    }
}
