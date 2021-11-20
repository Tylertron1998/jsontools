using System;
using System.CommandLine;

namespace JsonTools
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			var commands = Commands.Build();

			commands.Invoke(args);
		}
	}
}
