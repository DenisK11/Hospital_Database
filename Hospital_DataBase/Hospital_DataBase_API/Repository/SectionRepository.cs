using Hospital_DataBase_API.Data;
using Hospital_DataBase_API.Models;
using Hospital_DataBase_API.Repository.IRepository;

namespace Hospital_DataBase_API.Repository
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        private readonly ApplicationDbContext _db;
        public SectionRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public async Task<Section> UpdateAsync(Section entity)
        {
            _db.Sections.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
