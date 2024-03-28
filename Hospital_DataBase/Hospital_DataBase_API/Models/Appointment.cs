using System.ComponentModel.DataAnnotations;

namespace Hospital_DataBase_API.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Section Section { get; set; }
        public DateTime Date { get; set; }
        public Procedure Procedure { get; set; }
        public User User { get; set; }
        public Doctor Doctor { get; set; }

    }
}
