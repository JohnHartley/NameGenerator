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
			Console.WriteLine("Hello World!");
			
			NameRandomiser nameMaker = new NameRandomiser();
			string [] name;
			for(int i=0;i<100;i++)
			{
				name = nameMaker.randomName(NameRandomiser.Gender.either);
				Console.WriteLine(name[0]+" "+name[1]);
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
	}
}