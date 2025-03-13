using Challenge_Odontoprev_API.Models;
using Challenge_Odontoprev_API.Repositories;
using Challenge_Odontoprev_API.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Challenge_Odontoprev_API.Controllers;

[Route("api/controller")]
[ApiController]
public class PacienteController : ControllerBase
{
    private readonly _IRepository<Paciente> _repository;
    private readonly IMapper _mapper;

    public PacienteController(_IRepository<Paciente> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pacientes = await _repository.GetAll();
        return Ok(pacientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var paciente = await _repository.GetById(id);
        if (paciente == null)
            return NotFound();
        return Ok(paciente);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Paciente paciente)
    {
        var newPaciente = await _repository.Create(paciente);
        return CreatedAtAction(nameof(GetById), new { id = paciente.Id}, paciente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id,[FromBody] Paciente paciente)
    {
        var existingPaciente = await _repository.GetById(id);
        if (existingPaciente == null)
            return NotFound();

        var updatedPaciente = await _repository.Update(paciente);
        return Ok(updatedPaciente);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var paciente = await _repository.Delete(id);
        return NoContent();
    }
}
