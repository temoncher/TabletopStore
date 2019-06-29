using System.ComponentModel.DataAnnotations;

namespace TabletopStore.Data.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string Email { get; set; }

        [Display(Name = "NewPassword")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [Display(Name = "Old password")]
        [Compare("NewPassword", ErrorMessage = "Password don't match!")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
    }
}
