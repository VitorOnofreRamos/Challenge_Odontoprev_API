using Challenge_Odontoprev_API.Models;
using Challenge_Odontoprev_API.Repositories;

namespace Challenge_Odontoprev_API.Infrastructure;

public interface IUnitOfWork : IDisposable
{
    _IRepository<Paciente> Pacientes { get; }
    _IRepository<Dentista> Dentistas { get; }
    _IRepository<Consulta> Consultas { get; }
    _IRepository<HistoricoConsulta> Historicos { get; }
    
    Task<int> CompleteAsync();
}