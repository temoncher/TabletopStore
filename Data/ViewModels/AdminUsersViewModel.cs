using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabletopStore.Models;

namespace TabletopStore.Data.ViewModels
{
    public class AdminUsersViewModel
    {
        public IEnumerable<User> Users { get; set; }
    }
}
