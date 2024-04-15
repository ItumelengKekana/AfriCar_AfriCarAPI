using AfriCar_AfriCarAPI.Models.Dto;
using AfriCar_AfriCarAPI.Models;

namespace AfriCar_AfriCarAPI.Repository.IRepository
{
	public interface IUserRepository
	{
		bool IsUniqueUser(string username);
		Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
		Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO);
	}
}
