using Microsoft.AspNetCore.Identity;
using TabletopStore.Models.Roles;

namespace TabletopStore.Data.ViewModels
{
    public class AdminProfileViewModel
    {
        public User User { get; set; }
        public string UserId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsSalesperson { get; set; }

    }
}
