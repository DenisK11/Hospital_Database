
using Hospital_DataBase_API.Models;

namespace Hospital_DataBase_API.Repository.IRepository
{
    public interface IProcedureRepository : IRepository<Procedure>
    {
        Task<Procedure> UpdateAsync(Procedure entity);
    }
}
