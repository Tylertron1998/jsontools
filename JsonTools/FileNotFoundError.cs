using Remora.Results;

namespace JsonTools
{
	public record FileNotFoundError : IResultError
	{
		public string Message => "File is not found.";
	}
}
