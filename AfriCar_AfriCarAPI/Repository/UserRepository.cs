using AfriCar_AfriCarAPI.Data;
using AfriCar_AfriCarAPI.Models.Dto;
using AfriCar_AfriCarAPI.Models;
using AfriCar_AfriCarAPI.Repository.IRepository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AfriCar_AfriCarAPI.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _db;
		private string secretKey;

		public UserRepository(ApplicationDbContext db, IConfiguration configuration)
		{
			_db = db;
			secretKey = configuration.GetValue<string>("ApiSettings:Secret");
		}

		public bool IsUniqueUser(string username)
		{
			var user = _db.LocalUsers.FirstOrDefault(x => x.UserName == username);
			if (user == null)
			{
				return true;
			}

			return false;
		}

		public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
		{
			var user = _db.LocalUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower() && u.Password == loginRequestDTO.Password);

			if (user == null)
			{
				return new LoginResponseDTO()
				{
					Token = "",
					User = null,
				};
			}

			//generate token if user was found
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(secretKey);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Id.ToString()),
					new Claim(ClaimTypes.Role, user.Role)
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			LoginResponseDTO loginResponseDTO = new LoginResponseDTO
			{
				Token = tokenHandler.WriteToken(token),
				User = user,
			};

			return loginResponseDTO;
		}

		public async Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO)
		{
			LocalUser user = new()
			{
				UserName = registrationRequestDTO.UserName,
				Password = registrationRequestDTO.Password,
				Name = registrationRequestDTO.Name,
				Role = registrationRequestDTO.Role,
			};

			_db.LocalUsers.Add(user);
			await _db.SaveChangesAsync();
			user.Password = "";
			return user;
		}
	}
}
