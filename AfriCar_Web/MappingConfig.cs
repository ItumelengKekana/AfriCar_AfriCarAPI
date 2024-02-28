using AfriCar_Web.Models.Dto;
using AutoMapper;

namespace AfriCar_Web
{
	public class MappingConfig : Profile
	{
		public MappingConfig()
		{
			CreateMap<CarDTO, CarCreateDTO>().ReverseMap();
			CreateMap<CarDTO, CarUpdateDTO>().ReverseMap();

			CreateMap<CarNumberDTO, CarNumberCreateDTO>().ReverseMap();
			CreateMap<CarNumberDTO, CarNumberUpdateDTO>().ReverseMap();
		}
	}
}
