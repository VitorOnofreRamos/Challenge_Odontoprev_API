using Challenge_Odontoprev_API.Services.APIs;
using Challenge_Odontoprev_API.Services.APIs.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class EnderecoController : ControllerBase
{
    private readonly IEnderecoService _enderecoService;

    public EnderecoController(IEnderecoService enderecoService)
    {
        _enderecoService = enderecoService;
    }

    [HttpGet("consultar-cep/{cep}")]
    public async Task<IActionResult> ConsultarCep(string cep)
    {
        var resultado = await _enderecoService.ConsultarCepAsync(cep);
        if (resultado.Erro)
        {
            return NotFound(new { Mensagem = "CEP não encontrado." });
        }
        return Ok(resultado);
    }
}