using Practice_WebApp_MVC_Venkat_TT.Models;
using System.ComponentModel.DataAnnotations;

namespace Practice_WebApp_MVC_Venkat_TT.ViewModels
{
    public class EmployeeViewModel
    {
        [Required(ErrorMessage = "Enter Name")]
        public string? Name { get; set; }

        [Required]
        //[RegularExpression(@"^[A-Za-z0-9]_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
        [RegularExpression(@"^[A-Za-z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
        [Display(Name = "Personal Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Enter Department")]
        public Dept? Department { get; set; }

        public List<IFormFile> Photos { get; set; }
    }
}
