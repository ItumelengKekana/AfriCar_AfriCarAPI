using AfriCar_Web.Models;
using AfriCar_Web.Models.Dto;
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

		public async Task<IActionResult> UpdateCar(int carId)
		{
			var response = await _carService.GetAsync<APIResponse>(carId);
			if (response != null && response.isSuccess)
			{
				CarDTO model = JsonConvert.DeserializeObject<CarDTO>(Convert.ToString(response.Result));

				return View(_mapper.Map<CarUpdateDTO>(model));
			}

			return NotFound();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UpdateCar(CarUpdateDTO model)
		{
			if (ModelState.IsValid)
			{
				var response = await _carService.UpdateAsync<APIResponse>(model);
				if (response != null && response.isSuccess)
				{
					return RedirectToAction(nameof(IndexCar));
				}
			}
			return View(model);
		}

		public async Task<IActionResult> DeleteCar(int carId)
		{
			var response = await _carService.GetAsync<APIResponse>(carId);
			if (response != null && response.isSuccess)
			{
				CarDTO model = JsonConvert.DeserializeObject<CarDTO>(Convert.ToString(response.Result));

				return View(model);
			}

			return NotFound();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteCar(CarDTO model)
		{
			var response = await _carService.DeleteAsync<APIResponse>(model.Id);
			if (response != null && response.isSuccess)
			{
				return RedirectToAction(nameof(IndexCar));
			}

			return View(model);
		}
	}
}
