namespace Hospital_DataBase_API.Models.Dto
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public float Cost { get; set; }
        public Section Section { get; set; }
        public DateTime Date { get; set; }
    }
}
