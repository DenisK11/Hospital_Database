namespace Hospital_DataBase_API.Models
{
    public class Doctor : User
    {
        public Section Section { get; set; }
        public int Years { get; set; }
    }
}
