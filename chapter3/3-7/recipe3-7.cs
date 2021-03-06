using System;
using System.IO;
using System.Text.RegularExpressions;

public class Recipe
{
	private static Regex _Regex = new Regex("^(?<f1>.{10})(?<f2>.{30})(?<f3>.{15})");

	public void Run(string fileName)
	{
		String line;
		int lineNbr = 0;
		using (StreamReader sr = new StreamReader(fileName))
		{
			while(null != (line = sr.ReadLine()))
			{
				lineNbr++;
				if (_Regex.IsMatch(line))
				{
					_Regex.Match(line).Result("${f2}");
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
