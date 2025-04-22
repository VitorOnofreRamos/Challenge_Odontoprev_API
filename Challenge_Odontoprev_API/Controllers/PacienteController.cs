using Challenge_Odontoprev_API.Models;
using Challenge_Odontoprev_API.Repositories;
using Challenge_Odontoprev_API.Services.APIs;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Challenge_Odontoprev_API.DTOs;

namespace Challenge_Odontoprev_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PacienteController : ControllerBase
{
    private readonly _IRepository<Paciente> _repository;
    private readonly IMapper _mapper;
    private readonly IEnderecoService _enderecoService;

    public PacienteController(
        _IRepository<Paciente> repository, 
        IMapper mapper,
        IEnderecoService enderecoService)
    {
        _repository = repository;
        _mapper = mapper;
        _enderecoService = enderecoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pacientes = await _repository.GetAll();
        return Ok(_mapper.Map<IEnumerable<PacienteReadDTO>>(pacientes));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var paciente = await _repository.GetById(id);
        if (paciente == null)
            return NotFound();
        return Ok(_mapper.Map<PacienteReadDTO>(paciente));
    }

    [HttpPost]
    public async Task<IActionResult> Create(PacienteCreateDTO dto)
    {
        //Validar o CEP e endereço antes de persistir
        if (!string.IsNullOrEmpty(dto.CEP))
        {
            var enderecoResponse = await _enderecoService.ValidarEnderecoAsync(dto.CEP, dto.Endereco);
            if (!enderecoResponse)
                return BadRequest(new { Mensagem = "O endereco fornecido não é valido para o CEP informado." });
        }

        var paciente = _mapper.Map<Paciente>(dto);
        await _repository.Insert(paciente);

        return CreatedAtAction(
            nameof(GetById), 
            new { id = paciente.Id}, 
            _mapper.Map<PacienteReadDTO>(paciente)
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, PacienteCreateDTO dto)
    {
        var existingPaciente = await _repository.GetById(id);
        if (existingPaciente == null)
            return NotFound();

        //Validar o CEP e endereço antes de persistir
        if (!string.IsNullOrEmpty(dto.CEP))
        {
            var enderecoResponse = await _enderecoService.ValidarEnderecoAsync(dto.CEP, dto.Endereco);
            if (!enderecoResponse)
                return BadRequest(new { Mensagem = "O endereco fornecido não é valido para o CEP informado." });
        }

        _mapper.Map(dto, existingPaciente);
        await _repository.Update(existingPaciente);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _repository.Delete(id);
        return NoContent();
    }

    // Endpoint adicional para consultar endereço por CEP
    [HttpGet("consultar-cep/{cep}")]
    public async Task<IActionResult> ConsultarEnderecoPorCep(string cep)
    {
        try
        {
            var resultado = await _enderecoService.ConsultarCepAsync(cep);
            if (resultado.Erro)
            {
                return NotFound(new { Mensagem = "CEP não encontrado." });
            }
            return Ok(resultado);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Mensagem = "O CEP fornecido é inválido." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Mensagem = "Ocorreu um erro interno ao processar a solicitação." });
        }
    }
}
