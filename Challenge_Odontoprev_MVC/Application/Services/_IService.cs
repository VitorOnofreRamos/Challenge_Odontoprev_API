using Challenge_Odontoprev_MVC.Models.Entities;

namespace Challenge_Odontoprev_MVC.Application.Services;

public interface _IService<T> where T : _BaseEntity{
    Task<T> GetById(long id);
	Task<IEnumerable<T>> GetAll();
	Task Insert(T entity);
	Task Update(T entity);
	Task Delete(long id);
}

public interface IConsultaService : _IService<Consulta>{
    Task<bool> IsConsultaAgendada(string status);
    Task<IEnumerable<Consulta>> FindConsultasInTimePeriod(DateTime dataInicio, DateTime dataFim);
}

public interface IHitoricoConsultaService : _IService<HistoricoConsulta>
{
	Task<IEnumerable<HistoricoConsulta>> FindHistoricoConsultasByPacienteId(long id);
}
