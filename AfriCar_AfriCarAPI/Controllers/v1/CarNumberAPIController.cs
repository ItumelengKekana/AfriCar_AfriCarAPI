﻿using AfriCar_AfriCarAPI.Data;
using AfriCar_AfriCarAPI.Models;
using AfriCar_AfriCarAPI.Models.Dto;
using AfriCar_AfriCarAPI.Repository.IRepository;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AfriCar_AfriCarAPI.Controllers.v1
{
	[Route("api/v{version:apiVersion}/CarNumberAPI")]
	[ApiController]
	[ApiVersion("1.0")]
	public class CarNumberAPIController : ControllerBase
	{
		protected APIResponse _response;
		private readonly ICarNumberRepository _dbCarNumber;
		private readonly ICarRepository _dbCar;
		private readonly IMapper _mapper;

		public CarNumberAPIController(ICarNumberRepository dbCarNumber, IMapper mapper, ICarRepository dbCar)
		{
			_dbCarNumber = dbCarNumber;
			_mapper = mapper;
			_response = new();
			_dbCar = dbCar;
		}

		//GET All
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<APIResponse>> GetCarNumbers()
		{
			try
			{

				IEnumerable<CarNumberModel> carList = await _dbCarNumber.GetAllAsync(includeProperties: "Car");
				_response.Result = _mapper.Map<List<CarNumberDTO>>(carList);
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
		[HttpGet("{id:int}", Name = "GetCarNumber")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<APIResponse>> GetCarNumber(int id)
		{
			if (id == 0)
			{
				_response.StatusCode = HttpStatusCode.BadRequest;
				return BadRequest(_response);
			}

			var carNumber = await _dbCarNumber.GetAsync(x => x.CarNo == id);

			if (carNumber == null)
			{
				return NotFound();
			}

			_response.Result = _mapper.Map<CarNumberDTO>(carNumber);
			_response.StatusCode = HttpStatusCode.OK;
			return Ok(_response);
		}


		//CREATE POST
		[Authorize(Roles = "admin")]
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public async Task<ActionResult<APIResponse>> CreateCarNumber([FromBody] CarNumberCreateDTO createDTO)
		{
			try
			{
				if (await _dbCarNumber.GetAsync(u => u.CarNo == createDTO.CarNo) != null)
				{
					ModelState.AddModelError("ErrorMessages", "Car Number already exists");
					return BadRequest(ModelState);
				}

				if (await _dbCar.GetAsync(u => u.Id == createDTO.CarID) == null)
				{
					ModelState.AddModelError("ErrorMessages", "Car ID is invalid!");
					return BadRequest(ModelState);
				}

				if (createDTO == null)
				{
					return BadRequest(createDTO);
				}

				CarNumberModel carModel = _mapper.Map<CarNumberModel>(createDTO);

				await _dbCarNumber.CreateAsync(carModel);
				_response.Result = _mapper.Map<CarNumberDTO>(carModel);
				_response.StatusCode = HttpStatusCode.Created;

				return CreatedAtRoute("GetCar", new { id = carModel.CarNo }, _response);
			}
			catch (Exception ex)
			{
				_response.isSuccess = false;
				_response.ErrorMessages = new List<string> { ex.ToString() };
			}
			return _response;
		}


		//DELETE
		[Authorize(Roles = "admin")]
		[HttpDelete("{id:int}", Name = "DeleteCarNumber")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<APIResponse>> DeleteCarNumber(int id)
		{
			try
			{
				if (id == 0)
				{
					return BadRequest();
				}

				var car = await _dbCarNumber.GetAsync(u => u.CarNo == id);

				if (car == null)
				{
					return NotFound();
				}

				await _dbCarNumber.RemoveAsync(car);
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
		[HttpPut("{id:int}", Name = "UpdateCarNumber")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]

		public async Task<ActionResult<APIResponse>> UpdateCarNumber(int id, [FromBody] CarNumberUpdateDTO updateDTO)
		{
			try
			{

				if (updateDTO == null || id != updateDTO.CarNo)
				{
					return BadRequest();
				}

				CarNumberModel model = _mapper.Map<CarNumberModel>(updateDTO);

				await _dbCarNumber.UpdateAsync(model);
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
	}
}
