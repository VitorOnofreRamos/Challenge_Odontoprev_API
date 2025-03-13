using Challenge_Odontoprev_API.Models;

namespace Challenge_Odontoprev_API.Repositories;

public interface _IRepository<T> where T : _BaseEntity
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(long id);
    Task<T> Create(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(long id);
}
