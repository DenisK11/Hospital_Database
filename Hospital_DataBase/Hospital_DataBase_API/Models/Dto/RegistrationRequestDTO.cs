using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hospital_DataBase_API.Models.Dto
{
    public class RegistrationRequestDTO
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime RegisterDate { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string CNP { get; set; }
        public string SectionName { get; set; }
        public int? Years { get; set; }
    }
}
