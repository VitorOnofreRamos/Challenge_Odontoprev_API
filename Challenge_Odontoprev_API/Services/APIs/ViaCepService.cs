using Challenge_Odontoprev_API.Services.APIs.ResponseModel;
using Challenge_Odontoprev_API.Services.APIs;
using System.Net.Http;
using System.Text.Json;

namespace Challenge_Odontoprev_API.Services.APIs;

public class ViaCepService : IEnderecoService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://viacep.com.br/ws/";

    public ViaCepService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<EnderecoViaCepResponse> ConsultarCepAsync(string cep)
    {
        // Remove caracteres não numéricos do CEP
        cep = new string(cep.Where(char.IsDigit).ToArray());
        
        if (string.IsNullOrEmpty(cep) || cep.Length != 8)
        {
            return new EnderecoViaCepResponse { Erro = true };
        }

        try
        {
            string url = $"{BaseUrl}{cep}/json/";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var endereco = JsonSerializer.Deserialize<EnderecoViaCepResponse>(content,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                
                // A API ViaCEP retorna "erro": true quando o CEP não é encontrado
                if (endereco?.Cep == null)
                {
                    return new EnderecoViaCepResponse { Erro = true };
                }

                return endereco;
            }

            return new EnderecoViaCepResponse { Erro = true };
        } 
        catch (HttpRequestException ex)
        {
            return new EnderecoViaCepResponse { Erro = true };
        }
        catch (JsonException ex)
        {
            return new EnderecoViaCepResponse { Erro = true };
        }
    }
}