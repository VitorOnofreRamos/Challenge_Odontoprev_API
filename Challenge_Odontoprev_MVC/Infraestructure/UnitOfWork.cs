using Challenge_Odontoprev_MVC.Models.Entities;
using Challenge_Odontoprev_MVC.Repositories;

namespace Challenge_Odontoprev_MVC.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public _IRepository<_BaseEntity> _IRepository { get; private set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;

        _IRepository = new _Repository<_BaseEntity>(_context);
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}