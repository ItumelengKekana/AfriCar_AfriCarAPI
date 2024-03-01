using System.ComponentModel.DataAnnotations;

namespace AfriCar_Web.Models.Dto
{
	public class CarCreateDTO
	{
		[Required]
		[MaxLength(30)]
		public string Name { get; set; }

		public DateTime ReleaseYear { get; set; }

		public int Occupancy { get; set; }

		public string TransmissionType { get; set; }

		[Required]
		public double Rate { get; set; }

		public string? ImageUrl { get; set; }

		public string? Classification { get; set; }
	}
}
