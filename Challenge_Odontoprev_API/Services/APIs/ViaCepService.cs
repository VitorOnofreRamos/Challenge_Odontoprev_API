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
        catch (Exception)
        {
            return new EnderecoViaCepResponse { Erro = true };
        }
    }

    public async Task<bool> ValidarEnderecoAsync(string cep, string endereco)
    {
        if (string.IsNullOrEmpty(cep) || string.IsNullOrEmpty(endereco)) return false;

        var enderecoViaCep = await ConsultarCepAsync(cep);
        
        if (enderecoViaCep.Erro) return false;

        // Verificação se o endereço fornecido contém os elementos principais retornados pela API
        bool contiemLogradouro = !string.IsNullOrEmpty(enderecoViaCep.Logradouro) && 
                                endereco.Contains(enderecoViaCep.Logradouro, StringComparison.OrdinalIgnoreCase);
                                
        bool contiemBairro = !string.IsNullOrEmpty(enderecoViaCep.Bairro) && 
                            endereco.Contains(enderecoViaCep.Bairro, StringComparison.OrdinalIgnoreCase);
                            
        bool contiemCidade = !string.IsNullOrEmpty(enderecoViaCep.Localidade) && 
                            endereco.Contains(enderecoViaCep.Localidade, StringComparison.OrdinalIgnoreCase);
                            
        bool contiemUF = !string.IsNullOrEmpty(enderecoViaCep.Uf) && 
                        endereco.Contains(enderecoViaCep.Uf, StringComparison.OrdinalIgnoreCase);

        // Para consifderar válido, o endereço deve conter pelo menos logradouro e cidade
        return contiemLogradouro && contiemCidade;
    }
}