using AfriCar_AfriCarAPI.Data;
using AfriCar_AfriCarAPI.Models;
using AfriCar_AfriCarAPI.Models.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AfriCar_AfriCarAPI.Controllers
{
	[Route("api/CarAPI")]
	[ApiController]
	public class CarAPIController : ControllerBase
	{
		private readonly ApplicationDbContext _db;
		private readonly IMapper _mapper;

        public CarAPIController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
			_mapper = mapper;
        }

		//GET
        [HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<IEnumerable<CarDTO>>> GetCars()
		{
			IEnumerable<CarModel> carList = await _db.Cars.ToListAsync();
			return Ok(_mapper.Map<List<CarDTO>>(carList));
		}

		//GET Individual
		[HttpGet("id", Name = "GetCar")] //This implies that an id is needed to avoid an ambiguity error
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<CarDTO>> GetCar(int id)
		{
			if(id == 0)
			{
				return BadRequest();
			}

			var car = await _db.Cars.FirstOrDefaultAsync(x => x.Id == id);

			if(car == null)
			{
				return NotFound();
			}

			return Ok(_mapper.Map<CarDTO>(car));
		}


		//CREATE POST
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public async Task<ActionResult<CarDTO>> CreateCar([FromBody]CarCreateDTO createDTO)
		{
			if(await _db.Cars.FirstOrDefaultAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
			{
				ModelState.AddModelError("CustomError", "Car already exists");
				return BadRequest(ModelState);
			}

			if(createDTO == null)
			{
				return BadRequest(createDTO);
			}
			/*if(createDTO.Id == 0)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}*/

			/*CarModel carModel = new()
			{
				Name = car.Name,
				Details = car.Details,
				Id = car.Id,
				ImageUrl = car.ImageUrl,
				Occupancy = car.Occupancy,
				Rate = car.Rate,
				ReleaseYear = car.ReleaseYear,
				Classification = car.Classification,
			};*/

			CarModel carModel = _mapper.Map<CarModel>(createDTO);

			await _db.Cars.AddAsync(carModel);
			await _db.SaveChangesAsync();

			return CreatedAtRoute("GetCar", new {id = carModel.Id}, carModel);
		}


		//DELETE
		[HttpDelete("{id:int}", Name = "DeleteCar")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> DeleteCar(int id)
		{
			if (id == 0)
			{
				return BadRequest(); //returns a status of 400 if id is 0
			}

			var car = await _db.Cars.FirstOrDefaultAsync(u => u.Id == id); //link expression to find the item using the id

			if (car == null)
			{
				return NotFound(); //returns a status of 404 if the id does not match
			}

			_db.Cars.Remove(car); //remove the selected item
			await _db.SaveChangesAsync();
			return NoContent(); //returns a 204 No Content response instead of Ok (preference)
		}


		//PUT
		[HttpPut("{id:int}", Name = "UpdateCar")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]

		public async Task<IActionResult> UpdateCar(int id, [FromBody] CarUpdateDTO updateDTO)
		{
			if (updateDTO == null || id != updateDTO.Id)
			{
				return BadRequest();
			}

			/*CarModel carModel = new()
			{
				Name = car.Name,
				Details = car.Details,
				Id = car.Id,
				ImageUrl = car.ImageUrl,
				Occupancy = car.Occupancy,
				Rate = car.Rate,
				ReleaseYear = car.ReleaseYear,
				Classification = car.Classification,
			};*/

			CarModel model = _mapper.Map<CarModel>(updateDTO);

			_db.Cars.Update(model);
			await _db.SaveChangesAsync();

			return NoContent();
		}


		//PATCH

		[HttpPatch("{id:int}", Name = "UpdatePartialCar")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> UpdatePartialCar(int id, JsonPatchDocument<CarUpdateDTO> patchCar)
		{
			if (patchCar == null || id == 0)
			{
				return BadRequest();
			}

			var car = await _db.Cars.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

			/*CarModel carModel = new()
			{
				Name = car.Name,
				Details = car.Details,
				Id = car.Id,
				ImageUrl = car.ImageUrl,
				Occupancy = car.Occupancy,
				Rate = car.Rate,
				ReleaseYear = car.ReleaseYear,
				Classification = car.Classification,
			};*/

			CarUpdateDTO carUpdateDTO = _mapper.Map<CarUpdateDTO>(car);


			if(car == null)
			{
				return BadRequest();
			}

			patchCar.ApplyTo(carUpdateDTO, ModelState);

			//converting CarUpdateDTO back to Car in order to save to the database
			CarModel carModel = _mapper.Map<CarModel>(carUpdateDTO);


			_db.Cars.Update(carModel);  //updating the appropriate model bound to the database
			await _db.SaveChangesAsync();

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return NoContent();
		}
	}
}
