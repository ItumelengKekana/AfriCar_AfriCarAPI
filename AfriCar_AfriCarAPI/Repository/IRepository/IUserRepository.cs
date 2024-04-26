using AfriCar_AfriCarAPI.Models.Dto;
using AfriCar_AfriCarAPI.Models;

/* This user repository contains action methods which perform the following actions:
 * IsUniqueUser - avoids having duplicate usernames
 * Login - allows the user to login
 * Register - allows the user to register
 */

namespace AfriCar_AfriCarAPI.Repository.IRepository
{
	public interface IUserRepository
	{
		bool IsUniqueUser(string username);
		Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
		Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO);
	}
}
