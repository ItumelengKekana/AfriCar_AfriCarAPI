using AfriCar_Web.Models;
using AfriCar_Web.Models.Dto;
using AfriCar_Web.Models.VM;
using AfriCar_Web.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Reflection;

namespace AfriCar_Web.Controllers
{
	public class CarNumberController : Controller
	{
		private readonly ICarNumberService _carNumberService;
		private readonly ICarService _carService;
		private readonly IMapper _mapper;

		public CarNumberController(ICarNumberService carNumberService, IMapper mapper, ICarService carService)
		{
			_carNumberService = carNumberService;
			_carService = carService;
			_mapper = mapper;
		}

		public async Task<IActionResult> IndexCarNumber()
		{
			List<CarNumberDTO> list = new();

			var response = await _carNumberService.GetAllAsync<APIResponse>();
			if (response != null && response.isSuccess)
			{
				list = JsonConvert.DeserializeObject<List<CarNumberDTO>>(Convert.ToString(response.Result));
			}

			return View(list);
		}

		public async Task<IActionResult> CreateCarNumber()
		{
			CarNumberCreateVM carNumberVM = new CarNumberCreateVM();
			var response = await _carService.GetAllAsync<APIResponse>();
			if (response != null && response.isSuccess)
			{
				carNumberVM.CarList = JsonConvert.DeserializeObject<List<CarDTO>>(Convert.ToString(response.Result)).Select(x => new SelectListItem
				{
					Text = x.Name,
					Value = x.Id.ToString(),

				});
			}
			return View(carNumberVM);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateCarNumber(CarNumberCreateVM model)
		{
			if (ModelState.IsValid)
			{
				var response = await _carNumberService.CreateAsync<APIResponse>(model.CarNumber);
				if (response != null && response.isSuccess)
				{
					return RedirectToAction(nameof(IndexCarNumber));
				}
				else
				{
					if (response.ErrorMessages.Count > 0)
					{
						ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
					}
				}
			}
			return View(model);

		}

		public async Task<IActionResult> UpdateCarNumber(int carId)
		{
			CarNumberUpdateVM carNumberUpdateVM = new CarNumberUpdateVM();

			var response = await _carNumberService.GetAsync<APIResponse>(carId);
			if (response != null && response.isSuccess)
			{
				CarNumberDTO model = JsonConvert.DeserializeObject<CarNumberDTO>(Convert.ToString(response.Result));

				carNumberUpdateVM.CarNumber = _mapper.Map<CarNumberUpdateDTO>(model);
			}

			response = await _carService.GetAllAsync<APIResponse>();
			if (response != null && response.isSuccess)
			{
				carNumberUpdateVM.CarList = JsonConvert.DeserializeObject<List<CarDTO>>(Convert.ToString(response.Result)).Select(x => new SelectListItem
				{
					Text = x.Name,
					Value = x.Id.ToString(),

				});
				return View(carNumberUpdateVM);
			}

			return NotFound();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UpdateCarNumber(CarNumberUpdateVM model)
		{
			if (ModelState.IsValid)
			{
				var response = await _carNumberService.UpdateAsync<APIResponse>(model.CarNumber);
				if (response != null && response.isSuccess)
				{
					return RedirectToAction(nameof(IndexCarNumber));
				}
				else
				{
					if (response.ErrorMessages.Count > 0)
					{
						ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
					}
				}
			}

			var res = await _carService.GetAllAsync<APIResponse>();
			if (res != null && res.isSuccess)
			{
				model.CarList = JsonConvert.DeserializeObject<List<CarDTO>>(Convert.ToString(res.Result)).Select(x => new SelectListItem
				{
					Text = x.Name,
					Value = x.Id.ToString(),

				});
			}

			return View(model);
		}

		public async Task<IActionResult> DeleteCarNumber(int carId)
		{
			CarNumberDeleteVM carNumberDeleteVM = new CarNumberDeleteVM();

			var response = await _carNumberService.GetAsync<APIResponse>(carId);
			if (response != null && response.isSuccess)
			{
				CarNumberDTO model = JsonConvert.DeserializeObject<CarNumberDTO>(Convert.ToString(response.Result));
				carNumberDeleteVM.CarNumber = model;

				return View(model);
			}

			response = await _carService.GetAllAsync<APIResponse>();
			if (response != null && response.isSuccess)
			{
				carNumberDeleteVM.CarList = JsonConvert.DeserializeObject<List<CarDTO>>(Convert.ToString(response.Result)).Select(x => new SelectListItem
				{
					Text = x.Name,
					Value = x.Id.ToString(),

				});
				return View(carNumberDeleteVM);
			}

			return NotFound();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteCarNumber(CarNumberDeleteVM model)
		{
			var response = await _carNumberService.DeleteAsync<APIResponse>(model.CarNumber.CarNo);
			if (response != null && response.isSuccess)
			{
				return RedirectToAction(nameof(IndexCarNumber));
			}

			return View(model);
		}
	}
}
