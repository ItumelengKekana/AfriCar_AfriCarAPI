using System.Security.AccessControl;
using static AfriCar_Utility.SD;

namespace AfriCar_Web.Models
{
	public class APIRequest
	{
		public ApiType ApiType { get; set; } = ApiType.GET;
		public string Url { get; set; }
		public object Data { get; set; }
		public string Token { get; set; }
	}
}
