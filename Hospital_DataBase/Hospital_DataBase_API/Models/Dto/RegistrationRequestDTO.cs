using System.ComponentModel.DataAnnotations;

namespace Hospital_DataBase_API.Models.Dto
{
    public class RegistrationRequestDTO
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public DateOnly RegisterDate { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string CNP { get; set; }
    }
}
