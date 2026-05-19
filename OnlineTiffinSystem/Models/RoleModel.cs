using System.ComponentModel.DataAnnotations;

namespace OnlineTiffinSystem.Models
{
    public class RoleModel
    {
        [Required(ErrorMessage ="Enter a Role")]
        public string RoleName { get; set; }    
    }
}
