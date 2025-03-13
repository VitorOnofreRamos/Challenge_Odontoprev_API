namespace Challenge_Odontoprev_API.DTOs;

public class DentistaCreateDTO
{
    public string Nome { get; set; }
    public string CRO { get; set; }
    public string Especialidade { get; set; }
    public string Telefone { get; set; }
}

public class DentistaReadDTO
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public string CRO { get; set; }
    public string Especialidade { get; set; }
    public string Telefone { get; set; }
}
