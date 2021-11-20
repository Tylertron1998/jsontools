using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;

namespace JsonTools
{
	public static class Commands
	{
		public static RootCommand Build()
		{
			var prettifyCommand = new Command("prettify")
			{
				new Argument<FileInfo>("originalFile", "The file to prettify").ExistingOnly(),
				new Argument<FileInfo>("newFile", "The new file to write.") { Arity = ArgumentArity.ZeroOrOne }
			};

			prettifyCommand.Handler = CommandHandler.Create((FileInfo originalFile, FileInfo? newFile) =>
			{
				var result = JsonTools.Format(originalFile.FullName, true, newFile?.FullName);

				if (!result.IsSuccess)
				{
					Console.Error.WriteLine(result.Error.Message);
				}
			});
			
			var	minifyCommand = new Command("minify")
            {
                new Argument<FileInfo>("originalFile", "The original file to minify.").ExistingOnly(),
                new Argument<FileInfo>("newFile", "The new file to write.") { Arity = ArgumentArity.ZeroOrOne }
            };
			
			minifyCommand.Handler = CommandHandler.Create((FileInfo originalFile, FileInfo? newFile) =>
            {
                var result = JsonTools.Format(originalFile.FullName, false, newFile?.FullName);
				
				if (!result.IsSuccess)
                {
                    Console.Error.WriteLine(result.Error.Message);
                }
			});
			
			var root = new RootCommand
			{
				prettifyCommand,
                minifyCommand
			};

			return root;
		}
	}
}
