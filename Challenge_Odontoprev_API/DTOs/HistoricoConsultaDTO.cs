namespace Challenge_Odontoprev_API.DTOs;

public class HistoricoConsultaCreateDTO
{
    public long Id_Consulta { get; set; }
    public DateTime Data_Atendimento { get; set; }
    public string Motivo_Consulta { get; set; }
    public string Observacoes { get; set; }
}

public class HistoricoConsultaReadDTO
{
    public long Id { get; set; }
    public long Id_Consulta { get; set; }
    public DateTime Data_Atendimento { get; set; }
    public string Motivo_Consulta { get; set; }
    public string Observacoes { get; set; }
}
