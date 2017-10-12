/*
 * Created by SharpDevelop.
 * User: John
 * Date: 5/09/2012
 * Time: 5:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NameMaker
{
	[TestFixture]
	public class TestNameRandomiser
	{
		[Test]
		public void RandomName()
		{
			NameRandomiser nr = new NameRandomiser();
			string []  name= nr.randomName(NameMaker.NameRandomiser.Gender.either);
			Assert.AreEqual(name.Length,2,"Two strings expected");
			Console.WriteLine("Random name is '{0} {1}'",name[0],name[1]);
		}
		
		[Test]
		public void RandomNames()
		{
			const int target = 1000000;
			List<string[]> names = new List<string[]>(target);
			NameRandomiser nr = new NameRandomiser();
			for (int i = 0; i < target; i++) {
				names.Add(nr.randomName(NameMaker.NameRandomiser.Gender.either));
			}
//			foreach(var n in names)
//				Console.WriteLine("Random name is '{0} {1}'",n[0],n[1]);
		}
		
		[Test]
		public void CheckFormat()
		{
			NameRandomiser nr = new NameRandomiser();
			NameRandomiser.FormatElement[] f = nr.checkFormat("[unknown]");
			Assert.IsNull(f);
			f = nr.checkFormat("[FirstName][space][LastName]");
			Assert.IsNotNull(f);
			Assert.AreEqual(NameRandomiser.FormatElement.FirstName,f[0]);
			Assert.AreEqual(NameRandomiser.FormatElement.space,f[1]);
			Assert.AreEqual(NameRandomiser.FormatElement.LastName,f[2]);
		}
		
		[Test]
		public void ApplyFormat()
		{
			NameRandomiser nr = new NameRandomiser();
			NameRandomiser.FormatElement[] f;
			
			f = nr.checkFormat("[FirstName]space][LastName]");  // missing [
			Assert.IsNull(f);
			
			f = nr.checkFormat("[FirstName][space][LastName]");
			Assert.IsNotNull(f);
			string [] name;
			name = nr.randomName();
			string result = nr.applyFormat(name,f);
			Assert.IsNotNull(result);
			
			name = new string[2] {"John", "Smith"};
			result = nr.applyFormat(name,f);
			Assert.AreEqual("John Smith",result);
			
			f = nr.checkFormat("[LastName][comma][Firstname]");
			result = nr.applyFormat(name,f);
			Assert.AreEqual("Smith,John",result);
			
			string s = "[LastName][comma][FistName]";  // missing r
			f = nr.checkFormat(s);
			Assert.IsNull(f);
			
			s = "[lastname][COMMA][Firstname]";  // mixed case OK
			f = nr.checkFormat(s);
			Assert.IsNotNull(f);
			
			s = "[FI][TAB][LI]";  // First initial + tab + last initial
			f = nr.checkFormat(s);
			Assert.IsNotNull(f);
			result = nr.applyFormat(name,f);
			Assert.AreEqual("J\tS",result);
		}
	}
}
