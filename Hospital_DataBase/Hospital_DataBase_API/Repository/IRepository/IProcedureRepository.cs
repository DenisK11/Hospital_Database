
using Hospital_DataBase_API.Models;

namespace Hospital_DataBase_API.Repository.IRepository
{
    public interface ISectionRepository : IRepository<Section>
    {
        Task<Section> UpdateAsync(Section entity);
    }
}
