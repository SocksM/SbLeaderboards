using System.Net;

namespace SbLeaderboards.Resources.Exceptions
{
	public class ApiException : Exception
	{
		public readonly HttpStatusCode StatusCode;
		public readonly string Content;

		public ApiException(string message, HttpStatusCode statusCode, string content) : base(message)
		{
			StatusCode = statusCode;
			Content = content;
		}
	}
}