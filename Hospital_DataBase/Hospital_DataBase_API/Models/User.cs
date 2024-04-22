using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_DataBase_API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string CNP { get; set; }
        public string Role { get; set; }

        [ForeignKey("Section")]
        public string? SectionName { get; set; }
        public Section? Section { get; set; }
        public int? Years { get; set; }

    }
}
