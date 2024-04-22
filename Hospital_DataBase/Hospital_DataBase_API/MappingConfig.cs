using AutoMapper;
using Hospital_DataBase_API.Models;
using Hospital_DataBase_API.Models.Dto;

namespace Hospital_DataBase_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Appointment, AppointmentDTO>();
            CreateMap<AppointmentDTO, Appointment>();

            CreateMap<Appointment, AppointmentCreateDTO>().ReverseMap();
            CreateMap<Appointment, AppointmentUpdateDTO>().ReverseMap();


            CreateMap<Procedure, ProcedureDTO>().ReverseMap();
            CreateMap<Procedure, ProcedureUpdateDTO>().ReverseMap();
            CreateMap<Procedure, ProcedureCreateDTO>().ReverseMap();

            CreateMap<Section, SectionDTO>().ReverseMap();
            CreateMap<Section, SectionUpdateDTO>().ReverseMap();
            CreateMap<Section, SectionCreateDTO>().ReverseMap();
        
        }  
    }
}
