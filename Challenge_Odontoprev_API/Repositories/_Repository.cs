using Challenge_Odontoprev_API.Data;
using Challenge_Odontoprev_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Challenge_Odontoprev_API.Repositories;

public class _Repository<T> : _IRepository<T> where T : _BaseEntity
{
    protected readonly ApplicationDbContext _context;
    private readonly DbSet<T> _entities;

    public _Repository(ApplicationDbContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _entities.ToListAsync();
    }

    public async Task<T> GetById(long id)
    {
        return await _entities.FindAsync(id);
    }

    public async Task<T> Create(T entity)
    {
        await _entities.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> Update(T entity)
    {
        _entities.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> Delete(long id)
    {
        var entity = await _entities.FindAsync(id);
        if (entity == null)
        {
            return null;
        }

        _entities.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
