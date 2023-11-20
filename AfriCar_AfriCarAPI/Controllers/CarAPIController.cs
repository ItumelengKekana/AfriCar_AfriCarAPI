using AfriCar_AfriCarAPI.Data;
using AfriCar_AfriCarAPI.Models;
using AfriCar_AfriCarAPI.Models.Dto;
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

        public CarAPIController(ApplicationDbContext db)
        {
            _db = db;
        }

		//GET
        [HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<IEnumerable<CarDTO>> GetCars()
		{
			return Ok(_db.Cars.ToList());
		}

		//GET Individual
		[HttpGet("id", Name = "GetCar")] //This implies that an id is needed to avoid an ambiguity error
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<CarDTO> GetCar(int id)
		{
			if(id == 0)
			{
				return BadRequest();
			}

			var car = _db.Cars.FirstOrDefault(x => x.Id == id);

			if(car == null)
			{
				return NotFound();
			}

			return Ok(car);
		}


		//CREATE POST
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public ActionResult<CarDTO> CreateCar([FromBody]CarDTO car)
		{
			if(_db.Cars.FirstOrDefault(u => u.Name.ToLower() == car.Name.ToLower()) != null)
			{
				ModelState.AddModelError("CustomError", "Car already exists");
				return BadRequest(ModelState);
			}

			if(car == null)
			{
				return BadRequest();
			}
			if(car.Id == 0)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}

			CarModel carModel = new()
			{
				Name = car.Name,
				Details = car.Details,
				Id = car.Id,
				ImageUrl = car.ImageUrl,
				Occupancy = car.Occupancy,
				Rate = car.Rate,
				ReleaseYear = car.ReleaseYear,
				Classification = car.Classification,
			};

			_db.Cars.Add(carModel);
			_db.SaveChanges();

			return CreatedAtRoute("GetCar", new {id = car.Id}, car);
		}


		//DELETE
		[HttpDelete("{id:int}", Name = "DeleteCar")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult DeleteCar(int id)
		{
			if (id == 0)
			{
				return BadRequest(); //returns a status of 400 if id is 0
			}

			var car = _db.Cars.FirstOrDefault(u => u.Id == id); //link expression to find the item using the id

			if (car == null)
			{
				return NotFound(); //returns a status of 404 if the id does not match
			}

			_db.Cars.Remove(car); //remove the selected item
			_db.SaveChanges();
			return NoContent(); //returns a 204 No Content response instead of Ok (preference)
		}


		//PUT
		[HttpPut("{id:int}", Name = "UpdateCar")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]

		public IActionResult UpdateCar(int id, [FromBody] CarDTO car)
		{
			if (car == null || id != car.Id)
			{
				return BadRequest();
			}

			CarModel carModel = new()
			{
				Name = car.Name,
				Details = car.Details,
				Id = car.Id,
				ImageUrl = car.ImageUrl,
				Occupancy = car.Occupancy,
				Rate = car.Rate,
				ReleaseYear = car.ReleaseYear,
				Classification = car.Classification,
			};

			_db.Cars.Update(carModel);
			_db.SaveChanges();

			return NoContent();
		}


		//PATCH

		[HttpPatch("{id:int}", Name = "UpdatePartialCar")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult UpdatePartialCar(int id, JsonPatchDocument<CarDTO> patchCar)
		{
			if (patchCar == null || id == 0)
			{
				return BadRequest();
			}

			var car = _db.Cars.AsNoTracking().FirstOrDefault(x => x.Id == id);

			CarModel carModel = new()
			{
				Name = car.Name,
				Details = car.Details,
				Id = car.Id,
				ImageUrl = car.ImageUrl,
				Occupancy = car.Occupancy,
				Rate = car.Rate,
				ReleaseYear = car.ReleaseYear,
				Classification = car.Classification,
			};

			_db.Cars.Update(carModel);
			_db.SaveChanges();

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return NoContent();
		}
	}
}
