using AfriCar_Utility;
using AfriCar_Web.Models;
using AfriCar_Web.Models.Dto;
using AfriCar_Web.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AfriCar_Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private readonly ICarService _carService;
		private readonly IMapper _mapper;

		public HomeController(ICarService carService, IMapper mapper, ILogger<HomeController> logger)
		{
			_carService = carService;
			_mapper = mapper;
			_logger = logger;

		}

		public async Task<IActionResult> Index()
		{
			List<CarDTO> list = new();

			var response = await _carService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
			if (response != null && response.isSuccess)
			{
				list = JsonConvert.DeserializeObject<List<CarDTO>>(Convert.ToString(response.Result));
			}

			return View(list);
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
