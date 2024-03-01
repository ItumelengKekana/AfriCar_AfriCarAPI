using AfriCar_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AfriCar_Web.Models.VM
{
	public class CarNumberCreateVM
	{
		public CarNumberCreateVM()
		{
			CarNumber = new CarNumberCreateDTO();
		}

		public CarNumberCreateDTO CarNumber { get; set; }

		[ValidateNever]
		public IEnumerable<SelectListItem> CarList { get; set; }
	}
}
