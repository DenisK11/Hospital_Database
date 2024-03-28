namespace Hospital_DataBase_API.Models
{
    public class Procedure
    {
        public string Name { get; set; }   
        public float Cost { get; set; }
        public TimeOnly Duration { get; set; }
        public string Description { get; set; }
        ICollection<Appointment> Appointments { get; set; }

    }
}
