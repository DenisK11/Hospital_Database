using Hospital_DataBase_API.Data;
using Hospital_DataBase_API.Models;
using Hospital_DataBase_API.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Hospital_DataBase_API.Controllers
{
    [Route("api/AppointmentAPI")]
    [ApiController]
    public class AppointmentAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<AppointmentDTO> GetAppointments()
        {
            return AppointmentStore.appointmentList;
        }
    }
}
