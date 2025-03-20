using Challenge_Odontoprev_MVC.Models.Entities;
using Challenge_Odontoprev_MVC.Repositories;

namespace Challenge_Odontoprev_MVC.Infrastructure;

public interface IUnitOfWork : IDisposable
{
    _IRepository<_BaseEntity> _IRepository { get; }

    Task<int> CompleteAsync();
}