using Microsoft.EntityFrameworkCore;
using Challenge_Odontoprev_API.Models;

namespace Challenge_Odontoprev_API.Data;

public class ApplicationDbContext : DbContext
{
    ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Dentista> Dentistas { get; set; }
    public DbSet<Consulta> Consultas { get; set; }
    public DbSet<HistoricoConsulta> HistoricosConsulta { get; set; }
}
