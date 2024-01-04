using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AfriCar_AfriCarAPI.Models
{
	public class CarNumberModel
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int CarNo { get; set; }

		[ForeignKey("Car")]
		public int CarID { get; set; }
		public CarModel Car { get; set; }
		public string SpecialDetails { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime UpdatedDate { get; set; }
	}
}
