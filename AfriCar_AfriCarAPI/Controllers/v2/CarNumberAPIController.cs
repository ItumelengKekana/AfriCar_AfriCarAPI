using AfriCar_AfriCarAPI.Data;
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

/* This is version 2.0 of the controller added for extensibility and to learn API versioning
*/

namespace AfriCar_AfriCarAPI.Controllers.v2
{
    [Route("api/v{version:apiVersion}/CarNumberAPI")]
    [ApiController]
    [ApiVersion("2.0")]
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

		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "Itumeleng", "Kekana", "Made This", ":)" };
		}

	}
}
