using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Hospital_DataBase_API.Models.Dto
{
    public class AppointmentCreateDTO
    {
        [Required]
        public string ProcedureName { get; set; }

        public string SectionName { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Doctor {  get; set; }
    }
}
