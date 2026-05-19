using System.ComponentModel.DataAnnotations;

namespace Project_Model.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage ="Enter Valid Email")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string EmailAddress { get; set; }
        [MinLength(8,ErrorMessage ="Password Length minimum 8 character")]
        [Required(ErrorMessage ="Please Enter correct Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter confirm Password")]
        [Compare("Password",ErrorMessage ="Not Valid")]
        public string ConfirmPassword {  get; set; }
    }
}
