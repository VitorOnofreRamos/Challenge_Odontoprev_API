namespace Challenge_Odontoprev_API.Models;

public class Dentista : _BaseEntity
{
    public string Nome { get; set; }
    public string CRO { get; set; }
    public string Especialidade { get; set; }
    public string Telefone { get; set; }
}
