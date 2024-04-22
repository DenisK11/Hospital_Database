using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_DataBase_API.Models
{
    public class Procedure
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Name { get; set; }   
        public float Cost { get; set; }
        public TimeOnly Duration { get; set; }
        public string Description { get; set; }

    }
}
