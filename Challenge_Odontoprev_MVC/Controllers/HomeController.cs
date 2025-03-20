using Challenge_Odontoprev_MVC.Application.Services;
using Challenge_Odontoprev_MVC.Application.DTOs;
using Challenge_Odontoprev_MVC.Models;
using Challenge_Odontoprev_MVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Challenge_Odontoprev_MVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;


		public HomeController(
			ILogger<HomeController> logger,
			_IService<Consulta> consulta,
			_IService<Paciente> paciente,
			_IService<Dentista> dentista)
		{
			_logger = logger;
			_consultaService = consulta;
			_pacienteService = paciente;
			_dentistaService = dentista;
		}

		public async Task<IActionResult> Index()
		{
			var consultas = await _consultaService.GetAll();

			var consultasDTO = consultas.Select(a => new ConsultaReadDTO 
			{ 
				ID = a.Id,
				Data_Consulta = a.Data_Consulta,
				ID_Paciente = a.ID_Paciente,
				ID_Dentista = a.ID_Dentista,
				Status = a.Status,
			}).ToList();

			return View(consultasDTO);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
