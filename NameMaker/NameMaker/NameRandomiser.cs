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
		private Random random;	// Random number generator
		public enum Gender { either, female, male }
		public enum FormatElement {
			FirstName,LastName,FirstInitial,LastInitial,
			comma,space,tab
		}
		private FormatElement [] format;
		
		public NameRandomiser()
		{
			initNames();
			random = new Random();
			format = null;
		}
		
		public FormatElement[] checkFormat(string format)
		{
			//e.g [FirstName][comma][LastName]
			string [] delim = new string[1] {"]["};
			string [] tokens = format.Split(delim,StringSplitOptions.None);
			if(! tokens[0].StartsWith("["))
				return null;
			if(! tokens[tokens.Length-1].EndsWith("]"))
				return null;
			tokens[0] = tokens[0].Substring(1); // trim leading [
			string s = tokens[tokens.Length-1];
			s = s.Substring(0,s.Length-1);
			tokens[tokens.Length-1] = s;
			
			List<FormatElement> formatList = new List<NameRandomiser.FormatElement>();
			
			for(int i=0;i < tokens.Length; i++)
			{
				string t = tokens[i].ToLower();
				if(t.Equals("firstname"))
					formatList.Add(FormatElement.FirstName);
				else if(t.Equals("lastname"))
					formatList.Add(FormatElement.LastName);
				else if(t.Equals("fi"))
					formatList.Add(FormatElement.FirstInitial);
				else if(t.Equals("li"))
					formatList.Add(FormatElement.LastInitial);
				else if(t.Equals("firstinitial"))
					formatList.Add(FormatElement.FirstInitial);
				else if(t.Equals("lastinitial"))
					formatList.Add(FormatElement.LastInitial);
				else if(t.Equals("comma"))
					formatList.Add(FormatElement.comma);
				else if(t.Equals("space"))
					formatList.Add(FormatElement.space);
				else if(t.Equals("tab"))
					formatList.Add(FormatElement.tab);
				else
					return null;
			}
			this.format =  formatList.ToArray();
			return this.format;
		}
		
		public string applyFormat(string[] name,FormatElement[] format)
		{
			if(name == null) name = randomName();
			System.Diagnostics.Debug.Assert(name.Length == 2,"Expecting a name as a two element string array");
			string firstName = name[0];
			string lastname = name[1];
			string result = "";
			foreach(FormatElement f in format)
			{
				if(f == FormatElement.FirstName)
					result += firstName;
				else if(f == FormatElement.LastName)
					result += lastname;
				else if(f == FormatElement.FirstInitial)
					result += firstName[0];
				else if(f == FormatElement.LastInitial)
					result += lastname[0];
				else if(f == FormatElement.space)
					result += " ";
				else if(f == FormatElement.tab)
					result += "\t";
				else if(f == FormatElement.comma)
					result += ",";
				else
					System.Diagnostics.Debug.Fail("Unknown formatting enum: "+f.ToString());
			}
			return result;
		}
		
		public string [] randomName()
		{
			return randomName(Gender.either);
		}
		
		/// <summary>Generates a random name</summary>
		/// <param name="gender">Specify </param>
		/// <returns>Two element string array with element[0] as First Name and element[1] containing the last name or surname.</returns>
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
			ReadFile(FamilyNames,"names.txt");
			
			MaleNames = new List<string>();
			ReadFile(MaleNames,"male.txt");
			
			FemaleNames = new List<string>();
			ReadFile(FemaleNames,"female.txt");
		}

		private void ReadFile(List<string> theList,string fileName)
		{
			string line;
			using (StreamReader sr = new StreamReader(fileName)) {
				line = sr.ReadLine();
				while (line != null) {
					if( ! ((line.Trim().Equals("")) || (line.StartsWith("#"))))  // Line is neither blank or starting with # symbol
						theList.Add(line);
					line = sr.ReadLine();
				}
			}
		}
	}
}
