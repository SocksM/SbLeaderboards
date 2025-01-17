using System.Runtime.Serialization;

namespace SbLeaderboards.Resources.Exceptions
{
	public class NoEntitiesFoundException : Exception
	{
		public NoEntitiesFoundException()
		{
		}

		public NoEntitiesFoundException(string? message) : base(message)
		{
		}

		public NoEntitiesFoundException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected NoEntitiesFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}