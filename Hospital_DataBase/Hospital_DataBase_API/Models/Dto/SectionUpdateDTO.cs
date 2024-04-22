using System.ComponentModel.DataAnnotations;

namespace Hospital_DataBase_API.Models.Dto
{
    public class SectionUpdateDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
