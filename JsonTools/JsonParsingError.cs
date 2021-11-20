using Remora.Results;

namespace JsonTools
{
	public record JsonParsingError : IResultError
	{
		public string Message => "Failed to parse JSON.";
	}
}