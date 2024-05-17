using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice_WebApp_MVC_Venkat_TT.Models
{ 
    public class Employee
    {
        [Key]
        [Required(ErrorMessage = "Enter Employee Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string? Name { get; set; }

        [Required]
        //[RegularExpression(@"^[A-Za-z0-9]_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
        [RegularExpression(@"^[A-Za-z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
        [Display(Name="Personal Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Enter Department")]
        public Dept? Department { get; set; }

        [Column("PhotoPath")]
        public string? PhotoPath { get; set; }

        public string? PhotoName { get; set; }

        public bool IsDeleted { get; set; } = true;
    }
}
