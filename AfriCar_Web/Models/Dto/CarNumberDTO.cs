﻿using System.ComponentModel.DataAnnotations;

namespace AfriCar_Web.Models.Dto
{
	public class CarNumberDTO
	{
		[Required]
		public int CarNo { get; set; }

		[Required]
		public int CarID { get; set; }
		public string SpecialDetails { get; set; }
	}
}
