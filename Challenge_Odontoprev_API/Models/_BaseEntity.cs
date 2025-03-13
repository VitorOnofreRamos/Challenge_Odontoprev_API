namespace Challenge_Odontoprev_API.Models;

public abstract class _BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
