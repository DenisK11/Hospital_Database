using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hospital_DataBase_API.Models.Dto
{
    public class RegistrationRequestDTO
    {
        [Required(ErrorMessage = "Username is required")]
        [EmailAddress]
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime RegisterDate { get; set; }
        public string FullName { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number must be exactly 10 digits long and contain only numbers")]

        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "CNP is required")]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "CNP must be exactly 13 digits long and contain only numbers")]
        public string CNP { get; set; }
        public string SectionName { get; set; }
        public int? Years { get; set; }
    }
}
