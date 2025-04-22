using Challenge_Odontoprev_API.Services.APIs;
using Challenge_Odontoprev_API.Services.APIs.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class EnderecoController : ControllerBase
{
    private readonly IEnderecoService _enderecoService;
    private readonly ILogger<EnderecoController> _logger;

    public EnderecoController(IEnderecoService enderecoService, ILogger<EnderecoController> logger)
    {
        _enderecoService = enderecoService;
        _logger = logger;
    }

    [HttpGet("consultar-cep/{cep}")]
    public async Task<IActionResult> ConsultarCep(string cep)
    {
        try{
            var resultado = await _enderecoService.ConsultarCepAsync(cep);
            if (resultado.Erro)
            {
                return NotFound(new { Mensagem = "CEP não encontrado." });
            }
            return Ok(resultado);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "CEP inválido fornecido {Cep}", cep);
            return BadRequest(new { Mensagem = "O CEP fornecido é inválido." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao consultar CEP: {Cep}", cep);
            return StatusCode(500, new { Mensagem = "Ocorreu um erro interno ao processar a solicitação." });
        }
    }
}