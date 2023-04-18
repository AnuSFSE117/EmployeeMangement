using System.ComponentModel.DataAnnotations;

namespace EmployeeMangement.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }
       
        [StringLength(100, MinimumLength = 2)]

        [Required(ErrorMessage = "Name is mandatory")]
        [RegularExpression(".*[a-zA-z]+.*", ErrorMessage = "Numerical values are not alowed")]
        public string Name { get; set; }
        public long Phonenumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public int Pincode { get; set; }
        public int Salary { get; set; }

    }
   
}
