using System.ComponentModel.DataAnnotations;

namespace Project_Model.Models
{
    public class RoleModel
    {
        [Required(ErrorMessage ="Enter a Role")]
        public string RoleName { get; set; }    
    }
}
