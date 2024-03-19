using AfriCar_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

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
