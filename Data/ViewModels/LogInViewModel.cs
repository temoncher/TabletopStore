using System.ComponentModel.DataAnnotations;

namespace TabletopStore.Data.ViewModels
{
    public class LogInViewModel
    {
        [Required]
        [Display(Name="User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
