using Hospital_DataBase_API.Data;
using Hospital_DataBase_API.Models;
using Hospital_DataBase_API.Repository.IRepository;

namespace Hospital_DataBase_API.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private readonly ApplicationDbContext _db;
        public AppointmentRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public async Task<Appointment> UpdateAsync(Appointment entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Appointments.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
