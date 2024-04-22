using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_DataBase_API.Models
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Section")]
        public string SectionName { get; set; }
        public Section Section { get; set; }

        [ForeignKey("Procedure")]
        public string ProcedureName { get; set; }
        public Procedure Procedure { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Doctor")]
        public int? DoctorId { get; set; }
        public User Doctor { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
