using AfriCar_AfriCarAPI.Data;
using AfriCar_AfriCarAPI.Models.Dto;
using AfriCar_AfriCarAPI.Models;
using AfriCar_AfriCarAPI.Repository.IRepository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

namespace AfriCar_AfriCarAPI.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _db;
		private string secretKey;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IMapper _mapper;
		private readonly RoleManager<IdentityRole> _roleManager;

		public UserRepository(ApplicationDbContext db, IConfiguration configuration, UserManager<ApplicationUser> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager)
		{
			_db = db;
			secretKey = configuration.GetValue<string>("ApiSettings:Secret");
			_userManager = userManager;
			_mapper = mapper;
			_roleManager = roleManager;
		}

		public bool IsUniqueUser(string username)
		{
			var user = _db.ApplicationUsers.FirstOrDefault(x => x.UserName == username);
			if (user == null)
			{
				return true;
			}

			return false;
		}

		public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
		{
			var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower());

			bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);

			if (user == null || isValid == false)
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
			var roles = await _userManager.GetRolesAsync(user);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.UserName.ToString()),
					new Claim(ClaimTypes.Role, roles.FirstOrDefault())
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			LoginResponseDTO loginResponseDTO = new LoginResponseDTO
			{
				Token = tokenHandler.WriteToken(token),
				User = _mapper.Map<UserDTO>(user),
			};

			return loginResponseDTO;
		}

		public async Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO)
		{
			ApplicationUser user = new()
			{
				UserName = registrationRequestDTO.UserName,
				Email = registrationRequestDTO.UserName,
				NormalizedEmail = registrationRequestDTO.UserName.ToUpper(),
				Name = registrationRequestDTO.Name,
			};

			try
			{
				var result = await _userManager.CreateAsync(user, registrationRequestDTO.Password);
				if (result.Succeeded)
				{
					if (!_roleManager.RoleExistsAsync("admin").GetAwaiter().GetResult())
					{
						await _roleManager.CreateAsync(new IdentityRole("admin"));
						await _roleManager.CreateAsync(new IdentityRole("customer"));
					}
					await _userManager.AddToRoleAsync(user, "admin");
					var userToReturn = _db.ApplicationUsers.FirstOrDefault(u => u.UserName == registrationRequestDTO.UserName);

					return _mapper.Map<UserDTO>(userToReturn);
				}
			}
			catch
			{

			}

			return new UserDTO();
		}
	}
}
