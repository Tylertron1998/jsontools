using Remora.Results;

namespace JsonTools
{
	public record FileCannotBeWrittenError : IResultError
	{
		public string Message => "The file cannot be written";
	}
}