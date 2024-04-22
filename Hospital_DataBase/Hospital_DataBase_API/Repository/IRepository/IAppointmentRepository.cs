
using Hospital_DataBase_API.Models;

namespace Hospital_DataBase_API.Repository.IRepository
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<Appointment> UpdateAsync(Appointment entity);
    }
}
