using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using Remora.Results;

namespace JsonTools
{
	public static class JsonTools
	{
		private static readonly JsonWriterOptions PrettyOptions = new JsonWriterOptions { Indented = true, SkipValidation = true };
		private static readonly JsonWriterOptions MinifiedOptions = new JsonWriterOptions { Indented = false, SkipValidation = true };
		
		public static Result Format(string file, bool pretty, string? newName = null)
		{
			
			var options = pretty ? PrettyOptions : MinifiedOptions;

			var inputStream = File.Open(file, FileMode.Open, FileAccess.ReadWrite);

			if (!inputStream.CanRead)
			{
				return Result.FromError(new FileCannotBeReadError());
			}
				
			var node = JsonNode.Parse(inputStream);

			if (node is null)
			{
				return Result.FromError(new JsonParsingError());
			}

			if (newName is null)
			{

				if (!inputStream.CanWrite)
				{
					return Result.FromError(new FileCannotBeWrittenError());
				}

				var writer = new Utf8JsonWriter(inputStream, options);
					
				node.WriteTo(writer);
				
				writer.Flush();
			}
			else
			{
				var outputStream = File.OpenWrite(newName);

				if (!outputStream.CanWrite)
				{
					return Result.FromError(new FileCannotBeWrittenError());
				}
				
				var writer = new Utf8JsonWriter(outputStream, options);
				
				node.WriteTo(writer);
				
				writer.Flush();
			}
			
			return Result.FromSuccess();
		}
	}

}
