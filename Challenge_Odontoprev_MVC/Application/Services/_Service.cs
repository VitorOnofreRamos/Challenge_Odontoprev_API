using Challenge_Odontoprev_MVC.Models.Entities;
using Challenge_Odontoprev_MVC.Repositories;

namespace Challenge_Odontoprev_MVC.Application.Services;

public class _Service<T> : _IService<T> where T : _BaseEntity
{
	private readonly _IRepository<T> _repository;

	public _Service(_IRepository<T> repository)
	{
		_repository = repository;
	}

	public async Task<T> GetById(long id)
	{
		return await _repository.GetById(id);
	}

	public async Task<IEnumerable<T>> GetAll()
	{
		return await _repository.GetAll();
	}

	public async Task Insert(T entity)
	{
		await _repository.Insert(entity);
	}

	public async Task Update(T entity)
	{
		await _repository.Update(entity);
	}

	public async Task Delete(long id)
	{
		await _repository.Delete(id);
	}
}

public class ConsultaService : _Service<Consulta>, IConsultaService
{
	private readonly _IRepository<Consulta> _repository;

	public ConsultaService(_IRepository<Consulta> repository) : base(repository)
	{
		_repository = repository;
	}

	public async Task<bool> IsConsultaAgendada(string status)
	{
		var consultas = await _repository.GetAll();
		return consultas.Any(c => c.Status == status);
	}

	public async Task<IEnumerable<Consulta>> FindConsultasInTimePeriod(DateTime dataInicio, DateTime dataFim)
	{
		var consultas = await _repository.GetAll();
		return consultas.Where(c => c.Data_Consulta >= dataInicio && c.Data_Consulta <= dataFim);
	}
}

public class HistoricoConsultaService : _Service<HistoricoConsulta>, IHitoricoConsultaService
{
	private readonly _IRepository<HistoricoConsulta> _repository;

	public HistoricoConsultaService(_IRepository<HistoricoConsulta> repository) : base(repository)
	{
		_repository = repository;
	}

	public async Task<IEnumerable<HistoricoConsulta>> FindHistoricoConsultasByPacienteId(long id)
	{
		var historicos = await _repository.GetAll();
		return historicos.Where(h => h.ID_Consulta == id);
	}
}
