using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_DataBase_API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public DateOnly RegisterDate { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string CNP { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public string Role { get; set; }

    }
}
