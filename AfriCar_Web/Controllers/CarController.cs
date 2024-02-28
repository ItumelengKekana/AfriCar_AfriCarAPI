using AfriCar_Web.Models;
using AfriCar_Web.Models.Dto;
using AfriCar_Web.Services;
using AfriCar_Web.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AfriCar_Web.Controllers
{
	public class CarController : Controller
	{
		private readonly ICarService _carService;
		private readonly IMapper _mapper;

		public CarController(ICarService carService, IMapper mapper)
		{
			_carService = carService;
			_mapper = mapper;
		}

		public async Task<IActionResult> IndexCar()
		{
			List<CarDTO> list = new();

			var response = await _carService.GetAllAsync<APIResponse>();
			if (response != null && response.isSuccess)
			{
				list = JsonConvert.DeserializeObject<List<CarDTO>>(Convert.ToString(response.Result));
			}

			return View(list);
		}

		public async Task<IActionResult> CreateCar()
		{
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateCar(CarCreateDTO model)
		{
			if (ModelState.IsValid)
			{
				var response = await _carService.CreateAsync<APIResponse>(model);
				if (response != null && response.isSuccess)
				{
					return RedirectToAction(nameof(IndexCar));
				}
			}
			return View(model);
		}
	}
}
