using AfriCar_Utility;
using AfriCar_Web.Models;
using AfriCar_Web.Models.Dto;
using AfriCar_Web.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

		//GET
		public async Task<IActionResult> IndexCar()
		{
			List<CarDTO> list = new();

			var response = await _carService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
			if (response != null && response.isSuccess)
			{
				list = JsonConvert.DeserializeObject<List<CarDTO>>(Convert.ToString(response.Result));
			}

			return View(list);
		}

		//GET
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> CreateCar()
		{
			return View();
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> CreateCar(CarCreateDTO model)
		{
			if (ModelState.IsValid)
			{
				var response = await _carService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
				if (response != null && response.isSuccess)
				{
					TempData["success"] = "Car Created Successfully!";
					return RedirectToAction(nameof(IndexCar));
				}
			}
			TempData["error"] = "Error encountered";
			return View(model);
		}

		//GET
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> UpdateCar(int carId)
		{
			var response = await _carService.GetAsync<APIResponse>(carId, HttpContext.Session.GetString(SD.SessionToken));
			if (response != null && response.isSuccess)
			{
				CarDTO model = JsonConvert.DeserializeObject<CarDTO>(Convert.ToString(response.Result));

				return View(_mapper.Map<CarUpdateDTO>(model));
			}

			return NotFound();
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> UpdateCar(CarUpdateDTO model)
		{
			if (ModelState.IsValid)
			{
				var response = await _carService.UpdateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
				if (response != null && response.isSuccess)
				{
					TempData["success"] = "Car Updated Successfully!";
					return RedirectToAction(nameof(IndexCar));
				}
			}
			TempData["error"] = "Error encountered";
			return View(model);
		}

		//GET
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeleteCar(int carId)
		{
			var response = await _carService.GetAsync<APIResponse>(carId, HttpContext.Session.GetString(SD.SessionToken));
			if (response != null && response.isSuccess)
			{
				CarDTO model = JsonConvert.DeserializeObject<CarDTO>(Convert.ToString(response.Result));

				return View(model);
			}

			return NotFound();
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeleteCar(CarDTO model)
		{
			var response = await _carService.DeleteAsync<APIResponse>(model.Id, HttpContext.Session.GetString(SD.SessionToken));
			if (response != null && response.isSuccess)
			{
				TempData["success"] = "Car Deleted Successfully!";
				return RedirectToAction(nameof(IndexCar));
			}
			TempData["error"] = "Error encountered";
			return View(model);
		}
	}
}
