using System.ComponentModel.DataAnnotations;

namespace AfriCar_Web.Models.Dto
{
	public class CarUpdateDTO
	{
		[Required]
		public int Id { get; set; }

		[Required]
		[MaxLength(30)]
		public string Name { get; set; }

		[MaxLength(4)]
		public string ReleaseYear { get; set; }

		[Required]
		public int Occupancy { get; set; }

		public string Details { get; set; }

		[Required]
		public double Rate { get; set; }

		[Required]
		public string ImageUrl { get; set; }

		public string Classification { get; set; }
	}
}
