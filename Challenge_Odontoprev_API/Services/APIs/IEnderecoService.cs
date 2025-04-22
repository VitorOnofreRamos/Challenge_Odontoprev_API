using Challenge_Odontoprev_API.Services.APIs.ResponseModel;

namespace Challenge_Odontoprev_API.Services.APIs;

public interface IEnderecoService
{
    Task<EnderecoViaCepResponse> ConsultarCepAsync(string cep);
}