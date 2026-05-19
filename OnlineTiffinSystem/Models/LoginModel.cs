using System.ComponentModel.DataAnnotations;

namespace OnlineTiffinSystem.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Please Enter EmailAddres")]
        [EmailAddress(ErrorMessage ="Please Enter Valid Password")]
        public string EmailAddress {  get; set; }

        [Required(ErrorMessage ="Please Enter Password")]
        [MinLength(8,ErrorMessage ="Password must contain 8 character")]
        public string Password { get; set; }

        public bool RememberMe {  get; set; }
    }
}
