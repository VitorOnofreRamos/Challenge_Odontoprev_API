using Challenge_Odontoprev_API.Models;
using Challenge_Odontoprev_API.Models.MongoDBModel;
using Challenge_Odontoprev_API.Repositories.MongoDBRepository;
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
    private readonly EnderecoRepository _enderecoRepository;

    public PacienteController(
        _IRepository<Paciente> repository, 
        IMapper mapper,
        IEnderecoService enderecoService,
        EnderecoRepository _enderecoRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _enderecoService = enderecoService;
        _enderecoRepository = _enderecoRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pacientes = await _repository.GetAll();
        var listDto = new List<PacienteReadDTO>();

        foreach (var p in pacientes)
        {
            var dto = _mapper.Map<PacienteReadDTO>(p);
            var endereco = await _enderecoRepository.GetByIdAsync(p.IdEndereco);
            if (endereco != null)
            {
                dto.Logradouro = endereco.Logradouro;
                dto.Numero = endereco.Numero;
                dto.Complemento = endereco.Complemento;
                dto.Bairro = endereco.Bairro;
                dto.Cidade = endereco.Cidade;
                dto.Estado = endereco.Estado;
                dto.Cep = endereco.Cep;
            }
            listDto.Add(dto);
        }

        return Ok(listDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var paciente = await _repository.GetById(id);
        if (paciente == null)
            return NotFound();

        var dto = _mapper.Map<PacienteReadDTO>(paciente);
        var endereco = await _enderecoRepository.GetByIdAsync(paciente.IdEndereco);
        if (endereco != null)
        {
            dto.Logradouro = endereco.Logradouro;
            dto.Numero = endereco.Numero;
            dto.Complemento = endereco.Complemento;
            dto.Bairro = endereco.Bairro;
            dto.Cidade = endereco.Cidade;
            dto.Estado = endereco.Estado;
            dto.Cep = endereco.Cep;
        }

        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(PacienteCreateDTO dto)
    {
        //Validar o CEP e endereço antes de persistir
        if (!string.IsNullOrEmpty(dto.Cep))
        {
            var enderecoStr = $"{dto.Logradouro}, {dto.Numero}, {dto.Complemento}, {dto.Bairro}, {dto.Cidade}/{dto.Estado}";
            if (!await _enderecoService.ValidarEnderecoAsync(dto.Cep, enderecoStr))
                return BadRequest(new { Mensagem = "O Endereço inválido para o CEP informado." });
        }

        //Criar e salvar documento no de Endereco no MongoDB
        var endereco = new Endereco
        {
            Logradouro = dto.Logradouro,
            Numero = dto.Numero,
            Complemento = dto.Complemento,
            Bairro = dto.Bairro,
            Cidade = dto.Cidade,
            Estado = dto.Estado,
            Cep = dto.Cep
        };
        var enderecoCriado = await _enderecoRepository.CreateAsync(endereco);

        // Mapear o Paciente e atribuir o IdEndereco retornado
        var paciente = _mapper.Map<Paciente>(dto);
        paciente.IdEndereco = enderecoCriado.Id;

        // Persistir paciente no Oracle
        await _repository.Insert(paciente);

        // Rertorna DTO Completo
        var readDto = _mapper.Map<PacienteReadDTO>(paciente);
        readDto.Logradouro  = enderecoCriado.Logradouro;
        readDto.Numero      = enderecoCriado.Numero;
        readDto.Complemento = enderecoCriado.Complemento;
        readDto.Bairro      = enderecoCriado.Bairro;
        readDto.Cidade      = enderecoCriado.Cidade;
        readDto.Estado      = enderecoCriado.Estado;
        readDto.Cep         = enderecoCriado.Cep;

        return CreatedAtAction(
            nameof(GetById), 
            new { id = paciente.Id}, 
            readDto
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, PacienteCreateDTO dto)
    {
        var existingPaciente = await _repository.GetById(id);
        if (existingPaciente == null)
            return NotFound();

        //Validar o CEP e endereço antes de persistir
        if (!string.IsNullOrEmpty(dto.Cep))
        {
            var enderecoStr = $"{dto.Logradouro}, {dto.Numero}, {dto.Complemento}, {dto.Bairro}, {dto.Cidade}/{dto.Estado}";
            if (!await _enderecoService.ValidarEnderecoAsync(dto.Cep, enderecoStr))
                return BadRequest(new { Mensagem = "O Endereço inválido para o CEP informado." });
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
}
