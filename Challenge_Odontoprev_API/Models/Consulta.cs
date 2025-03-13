namespace Challenge_Odontoprev_API.Models;

public class Consulta : _BaseEntity
{
    public DateTime Data_Consulta { get; set; }
    public long ID_Paciente { get; set; }
    public Paciente Paciente { get; set; }
    public long ID_Dentista { get; set; }
    public Dentista Dentista { get; set; } 
    public string Status { get; set; }
}
