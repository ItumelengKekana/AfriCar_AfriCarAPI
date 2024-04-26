/* Log - this method logs the message during operation depending on its type 
 */

namespace AfriCar_AfriCarAPI.Logging
{
	public interface ILogging
	{
		public void Log(string message, string type);
	}
}
