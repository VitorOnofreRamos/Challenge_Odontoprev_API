namespace Challenge_Odontoprev_API.DTOs;

public class PacienteCreateDTO
{
    public string Nome { get; set; }
    public DateTime Data_Nascimento { get; set; }
    public string CPF { get; set; }
    public string Telefone { get; set; }
    public long Carteirinha { get; set; }

    //Dados do Endereço
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Cep { get; set; }
}

public class PacienteReadDTO
{
    public long ID { get; set; }
    public string Nome { get; set; }
    public DateTime Data_Nascimento { get; set; }
    public string CPF { get; set; }
    public string Telefone { get; set; }
    public long Carteirinha { get; set; }

    //Dados do Endereço
    public string IdEndereco { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Cep { get; set; }
}

