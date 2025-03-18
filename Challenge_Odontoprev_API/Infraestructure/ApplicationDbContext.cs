using Microsoft.EntityFrameworkCore;
using Challenge_Odontoprev_API.Models;

namespace Challenge_Odontoprev_API.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<Paciente> Patients { get; set; }
    public DbSet<Dentista> Doctors { get; set; }
    public DbSet<Consulta> Consultas { get; set; }
    public DbSet<HistoricoConsulta> Historicos { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}
