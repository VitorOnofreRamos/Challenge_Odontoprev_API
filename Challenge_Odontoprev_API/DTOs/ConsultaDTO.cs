namespace Challenge_Odontoprev_API.DTOs;

public class ConsultaCreateDTO
{
    public DateTime Data_Consulta { get; set; }
    public long Id_Paciente { get; set; }
    public long Id_Dentista { get; set; }
    public string Status { get; set; }
}

public class ConsultaReadDTO
{
    public long Id { get; set; }
    public DateTime Data_Consulta { get; set; }
    public long Id_Paciente { get; set; }
    public long Id_Dentista { get; set; }
    public string Status { get; set; }
}

