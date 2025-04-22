using Challenge_Odontoprev_API.Models;
using Challenge_Odontoprev_API.Repositories;

namespace Challenge_Odontoprev_API.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationOracleDbContext _context;

    public _IRepository<Paciente> Pacientes { get; }
    public _IRepository<Dentista> Dentistas { get; }
    public _IRepository<Consulta> Consultas { get; }
    public _IRepository<HistoricoConsulta> Historicos { get; }

    public UnitOfWork(
        ApplicationOracleDbContext context,
        _IRepository<Paciente> pacientes,
        _IRepository<Dentista> dentistas,
        _IRepository<Consulta> consultas,
        _IRepository<HistoricoConsulta> historicos)
    {
        _context = context;
        Pacientes = pacientes;
        Dentistas = dentistas;
        Consultas = consultas;
        Historicos = historicos;
    }

    public Task<int> CompleteAsync() => _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}