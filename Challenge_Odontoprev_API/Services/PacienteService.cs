namespace Challenge_Odontoprev_API.Services;

using Challenge_Odontoprev_API.Models;
using Challenge_Odontoprev_API.Repositories;

public class PacienteService : _IService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mong _enderecoRepostiory;
}