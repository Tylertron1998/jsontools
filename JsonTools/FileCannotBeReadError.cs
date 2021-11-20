using Remora.Results;

namespace JsonTools
{
	public record FileCannotBeReadError : IResultError
	{
		public string Message => "File cannot be read.";
	}
}
