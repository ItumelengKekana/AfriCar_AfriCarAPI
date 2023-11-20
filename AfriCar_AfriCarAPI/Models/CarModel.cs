using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AfriCar_AfriCarAPI.Models
{
	public class CarModel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Name { get; set; }

		public string Details { get; set; }

		public double Rate { get; set; }

		[MaxLength(4)]
		public string ReleaseYear { get; set; }

		public int Occupancy { get; set; }

		public string ImageUrl { get; set; }

		public string Classification { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime UpdatedDate { get; set; }
	}
}
