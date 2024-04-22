using System.ComponentModel.DataAnnotations;

namespace Hospital_DataBase_API.Models.Dto
{
    public class SectionCreateDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
