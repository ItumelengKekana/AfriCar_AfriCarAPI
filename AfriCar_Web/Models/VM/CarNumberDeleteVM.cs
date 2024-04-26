using AfriCar_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

/* CarList is a navigation property used to populate the dropdown menu with relevant car details
 */

namespace AfriCar_Web.Models.VM
{
	public class CarNumberDeleteVM
	{
		public CarNumberDeleteVM()
		{
			CarNumber = new CarNumberDTO();
		}

		public CarNumberDTO CarNumber { get; set; }

		[ValidateNever]
		public IEnumerable<SelectListItem> CarList { get; set; }
	}
}
