using System;
using System.IO;
using System.Text.RegularExpressions;

public class Recipe
{
	// Alternatively "([^,\"]+|\"([^\"]|\"\")*\")";
	private static string csvFieldRegex = @"([^,""]+|""([^""]|"""")*"")";
	private static Regex _Regex = new Regex(csvFieldRegex);

	public void Run(string fileName)
	{
		String line;
		int lineNbr = 0;
		using (StreamReader sr = new StreamReader(fileName))
		{
			while(null != (line = sr.ReadLine()))
			{
				lineNbr++;
				if (_Regex.Matches(line).Count == 3)
				{
					Console.WriteLine("Found match '{0}' at line {1}", 
						line, 
						lineNbr);
				}
			}
		}
	}	

	public static void Main( string[] args )
	{
		Recipe r = new Recipe();
		r.Run(args[0]);
	}
}
