using AfriCar_AfriCarAPI.Data;
using AfriCar_AfriCarAPI.Models;
using AfriCar_AfriCarAPI.Models.Dto;
using AfriCar_AfriCarAPI.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AfriCar_AfriCarAPI.Controllers
{
	[Route("api/CarAPI")]
	[ApiController]
	public class CarAPIController : ControllerBase
	{
		protected APIResponse _response;
		private readonly ICarRepository _dbCar;
		private readonly IMapper _mapper;

		public CarAPIController(ICarRepository dbCar, IMapper mapper)
		{
			_dbCar = dbCar;
			_mapper = mapper;
			this._response = new();
		}

		//GET
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<APIResponse>> GetCars()
		{
			try
			{

				IEnumerable<CarModel> carList = await _dbCar.GetAllAsync();
				_response.Result = _mapper.Map<List<CarDTO>>(carList);
				_response.StatusCode = HttpStatusCode.OK;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.isSuccess = false;
				_response.ErrorMessages = new List<string> { ex.ToString() };
			}
			return _response;
		}

		//GET Individual
		[HttpGet("{id:int}", Name = "GetCar")] //This implies that an id is needed to avoid an ambiguity error
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<APIResponse>> GetCar(int id)
		{
			if (id == 0)
			{
				_response.StatusCode = HttpStatusCode.BadRequest;
				return BadRequest(_response);
			}

			var car = await _dbCar.GetAsync(x => x.Id == id);

			if (car == null)
			{
				return NotFound();
			}

			_response.Result = _mapper.Map<CarDTO>(car);
			_response.StatusCode = HttpStatusCode.OK;
			return Ok(_response);
		}


		//CREATE POST
		[HttpPost]
		[Authorize(Roles = "admin")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public async Task<ActionResult<APIResponse>> CreateCar([FromBody] CarCreateDTO createDTO)
		{
			try
			{


				if (await _dbCar.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
				{
					ModelState.AddModelError("CustomError", "Car already exists");
					return BadRequest(ModelState);
				}

				if (createDTO == null)
				{
					return BadRequest(createDTO);
				}

				CarModel carModel = _mapper.Map<CarModel>(createDTO);

				await _dbCar.CreateAsync(carModel);
				_response.Result = _mapper.Map<CarDTO>(carModel);
				_response.StatusCode = HttpStatusCode.Created;

				return CreatedAtRoute("GetCar", new { id = carModel.Id }, _response);
			}
			catch (Exception ex)
			{
				_response.isSuccess = false;
				_response.ErrorMessages = new List<string> { ex.ToString() };
			}
			return _response;
		}


		//DELETE
		[HttpDelete("{id:int}", Name = "DeleteCar")]
		[Authorize(Roles = "admin")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<APIResponse>> DeleteCar(int id)
		{
			try
			{
				if (id == 0)
				{
					return BadRequest(); //returns a status of 400 if id is 0
				}

				var car = await _dbCar.GetAsync(u => u.Id == id); //link expression to find the item using the id

				if (car == null)
				{
					return NotFound(); //returns a status of 404 if the id does not match
				}

				await _dbCar.RemoveAsync(car); //remove the selected item
				_response.StatusCode = HttpStatusCode.NoContent;
				_response.isSuccess = true;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.isSuccess = false;
				_response.ErrorMessages = new List<string> { ex.ToString() };
			}
			return _response;
		}


		//PUT
		[Authorize(Roles = "admin")]
		[HttpPut("{id:int}", Name = "UpdateCar")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]

		public async Task<ActionResult<APIResponse>> UpdateCar(int id, [FromBody] CarUpdateDTO updateDTO)
		{
			try
			{

				if (updateDTO == null || id != updateDTO.Id)
				{
					return BadRequest();
				}

				CarModel model = _mapper.Map<CarModel>(updateDTO);

				await _dbCar.UpdateAsync(model);
				_response.StatusCode = HttpStatusCode.OK;
				_response.isSuccess = true;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.isSuccess = false;
				_response.ErrorMessages = new List<string> { ex.ToString() };
			}
			return _response;
		}


		//PATCH
		[Authorize(Roles = "admin")]
		[HttpPatch("{id:int}", Name = "UpdatePartialCar")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> UpdatePartialCar(int id, JsonPatchDocument<CarUpdateDTO> patchCar)
		{
			if (patchCar == null || id == 0)
			{
				return BadRequest();
			}

			var car = await _dbCar.GetAsync(x => x.Id == id, tracked: false);

			CarUpdateDTO carUpdateDTO = _mapper.Map<CarUpdateDTO>(car);


			if (car == null)
			{
				return BadRequest();
			}

			patchCar.ApplyTo(carUpdateDTO, ModelState);

			//converting CarUpdateDTO back to Car in order to save to the database
			CarModel carModel = _mapper.Map<CarModel>(carUpdateDTO);


			await _dbCar.UpdateAsync(carModel);  //updating the appropriate model bound to the database

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return NoContent();
		}
	}
}
