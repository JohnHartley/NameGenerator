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
		public static void Main(string[] args)
		{
			
			if(args.Length == 0)
			{
				help();
				return;
			}
			
			int count=0;
			// Scan Arguments
			if(args[0].ToUpper().StartsWith("/C:"))
			{
				string countStr = args[0].Substring(3);
				Int32.TryParse(countStr,out count);
			}
			
			NameRandomiser nameMaker = new NameRandomiser();
			string [] name;
			for(int i=0; i < count; i++)
			{
				name = nameMaker.randomName(NameRandomiser.Gender.either);
				Console.WriteLine(name[0]+" "+name[1]);
			}
			
		}
		public static void help()
		{
			Console.WriteLine("Name Maker");
			Console.WriteLine("");
			Console.WriteLine("NAMEMAKER /C:runs");
		}
	}
}