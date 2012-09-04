/*
 * Created by SharpDevelop.
 * User: John
 * Date: 3/09/2012
 * Time: 9:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;

namespace NameMaker
{
	/// <summary>
	/// Description of NameRandomiser.
	/// </summary>
	public class NameRandomiser
	{
		public NameRandomiser()
		{
			initNames();
			random = new Random();
		}
		
		private Random random;
		
		public enum Gender { either, female, male }
		
		public string [] randomName(Gender gender)
		{
			string [] name = new string[2];
			
			int g = random.Next(2);  // gives 0 or 1
			if(g == 0)
			name[0] = FemaleNames[random.Next(FemaleNames.Count)];
			else if (g==1) 
				name[0] = MaleNames[random.Next(MaleNames.Count)];
			else
				System.Diagnostics.Debug.Fail("Coin toss failed with a value of "+g.ToString());
			
			name[1] = FamilyNames[random.Next(FamilyNames.Count)];
			
			return name;
		}
		
		private List<String> FamilyNames;
		private List<String> MaleNames;
		private List<String> FemaleNames;
		
		private void initNames()
		{
			FamilyNames = new List<string>();
			string line;
			
			using(TextReader tr = new StreamReader("names.txt"))
			{
				line = tr.ReadLine();
				while(line != null)
				{
					FamilyNames.Add(line);
					line = tr.ReadLine();
				}
			}
			
			MaleNames = new List<string>();
			using(StreamReader sr = new StreamReader("male.txt"))
			{
				line = sr.ReadLine();
				while(line != null)
				{
					MaleNames.Add(line);
					line = sr.ReadLine();
				}
			}
			
			FemaleNames = new List<string>();
			using(StreamReader sr = new StreamReader("female.txt"))
			{
				line = sr.ReadLine();
				while(line != null)
				{
					FemaleNames.Add(line);
					line = sr.ReadLine();
				}
			}
		}
	}
}
