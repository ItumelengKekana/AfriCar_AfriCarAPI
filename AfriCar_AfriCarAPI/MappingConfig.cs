using AfriCar_AfriCarAPI.Models;
using AfriCar_AfriCarAPI.Models.Dto;
using AutoMapper;

namespace AfriCar_AfriCarAPI
{
	public class MappingConfig : Profile
	{
        public MappingConfig()
        {
            CreateMap<CarModel, CarDTO>();
            CreateMap<CarDTO, CarModel>();

            CreateMap<CarModel, CarCreateDTO>().ReverseMap();
            CreateMap<CarModel, CarUpdateDTO>().ReverseMap();
        }
    }
}
