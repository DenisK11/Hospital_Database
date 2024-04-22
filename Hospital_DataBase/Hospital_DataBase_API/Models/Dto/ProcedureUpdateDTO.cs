using System.ComponentModel.DataAnnotations;

namespace Hospital_DataBase_API.Models.Dto
{
    public class ProcedureUpdateDTO
    {
        [Required]
        public string Name { get; set; }
        public float Cost { get; set; }
        public TimeOnly Duration { get; set; }
        public string Description { get; set; }
    }
}
