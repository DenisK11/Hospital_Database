using Hospital_DataBase_API.Data;
using Hospital_DataBase_API.Models;
using Hospital_DataBase_API.Repository.IRepository;

namespace Hospital_DataBase_API.Repository
{
    public class ProcedureRepository : Repository<Procedure>, IProcedureRepository
    {
        private readonly ApplicationDbContext _db;
        public ProcedureRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public async Task<Procedure> UpdateAsync(Procedure entity)
        {
            _db.Procedures.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
