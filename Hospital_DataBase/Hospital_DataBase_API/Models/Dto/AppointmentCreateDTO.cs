using System.ComponentModel.DataAnnotations;

namespace Hospital_DataBase_API.Models.Dto
{
    public class AppointmentCreateDTO
    {
        [Required]
        public string ProcedureName { get; set; }
        [Required]
        public string SectionName { get; set; }
        public DateTime Date { get; set; }
    }
}
