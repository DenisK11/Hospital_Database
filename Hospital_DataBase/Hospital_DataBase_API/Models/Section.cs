namespace Hospital_DataBase_API.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

    }
}
