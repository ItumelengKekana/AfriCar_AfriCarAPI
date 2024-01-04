using System.ComponentModel.DataAnnotations;

namespace AfriCar_AfriCarAPI.Models.Dto
{
	public class CarNumberUpdateDTO
	{
		[Required]
		public int CarNo { get; set; }

		[Required]
		public int CarID { get; set; }
		public string SpecialDetails { get; set; }
	}
}
