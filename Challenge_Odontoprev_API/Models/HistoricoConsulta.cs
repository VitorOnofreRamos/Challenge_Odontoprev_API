namespace Challenge_Odontoprev_API.Models;

public class HistoricoConsulta : _BaseEntity
{
    public long Id_Consulta { get; set; }
    public Consulta Consulta { get; set; }
    public DateTime Data_Atendimento { get; set; }
    public string Motivo_Consulta { get; set; }
    public string Obsevacoes { get; set; }
}
