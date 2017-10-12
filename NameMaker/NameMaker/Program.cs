/*
 * Created by SharpDevelop.
 * User: John
 * Date: 3/09/2012
 * Time: 7:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;

namespace NameMaker
{
	class Program
	{
		public static string defaultFormat = "[FirstName][space][LastName]";  // standard format
		
		public static void Main(string[] args)
		{
			
			if(args.Length == 0)
			{
				help();
				return;
			}
			
			int count = 10;
			
			int index=0;
			// Scan Arguments
			while(index < args.Length)
			{
				
				if(args[index].ToUpper().StartsWith("/C:"))   // Count parameter
				{
					string countStr = args[0].Substring(3);
					Int32.TryParse(countStr,out count);
				}
				else if (args[index].ToUpper().StartsWith("/F:"))  // Format parameter
				{
					defaultFormat = args[index].Substring(3);
				}
				else if (args[index].ToUpper().StartsWith("/H"))  // Format parameter
				{
					help();
					return;
				}
				else
				{
					Console.WriteLine("Unknown argument");
					return;
				}
				
				index++;
			}
			
			NameRandomiser nameMaker = new NameRandomiser();
			string [] name;
			
			NameRandomiser.FormatElement[] formatList;
			formatList = nameMaker.checkFormat(defaultFormat);
			if(formatList == null)
			{
				Console.WriteLine("Invalid format '"+defaultFormat+"'");
				return;
			}
			
			for(int i=0; i < count; i++)
			{
				name = nameMaker.randomName(NameRandomiser.Gender.either);
				Console.WriteLine(nameMaker.applyFormat(name,formatList));
			}
			
		}
		public static void help()
		{
			Console.WriteLine("Name Maker");
			Console.WriteLine("");
			Console.WriteLine("NAMEMAKER [/C:runs][/F:format]");
			Console.WriteLine("");
			Console.WriteLine("Where runs is the number names to generate");
			Console.WriteLine("Where format may consist of the folowing items:");
			Console.WriteLine("Formatting options:");
			Console.WriteLine("[FirstName]   First (given) name");
			Console.WriteLine("[LastName]    Last (family) name");
			Console.WriteLine("[FI]          First Initial");
			Console.WriteLine("[LI]          Last Initial");
			Console.WriteLine("[space]       Space character");
			Console.WriteLine("[comma]       ,");
			Console.WriteLine("[tab]         Tab character");
			Console.WriteLine("");
			Console.WriteLine("Default format is {0}",defaultFormat);
		}
	}
}