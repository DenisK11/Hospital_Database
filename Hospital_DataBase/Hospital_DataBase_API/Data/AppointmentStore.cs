using Hospital_DataBase_API.Models.Dto;

namespace Hospital_DataBase_API.Data
{
    public static class AppointmentStore
    {
        public static List<AppointmentDTO> appointmentList = new List<AppointmentDTO> {
             new AppointmentDTO {Id=1,Cost=10,Section=SectionStore.sectionList.FirstOrDefault(s=>s.Id==1)},
             new AppointmentDTO {Id=2,Cost=15,Section=SectionStore.sectionList.FirstOrDefault(s=>s.Id==2)}
             };
    }
}
