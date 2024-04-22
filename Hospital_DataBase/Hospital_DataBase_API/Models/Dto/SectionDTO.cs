using System.ComponentModel.DataAnnotations;

namespace Hospital_DataBase_API.Models.Dto
{
    public class SectionDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
