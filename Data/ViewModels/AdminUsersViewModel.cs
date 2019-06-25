using System.Collections.Generic;
using TabletopStore.Models.Roles;

namespace TabletopStore.Data.ViewModels
{
    public class AdminUsersViewModel
    {
        public IEnumerable<User> Users { get; set; }
    }
}
