using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BirthdayCS
{
	class Program
	{
		static void Main(string[] args)
		{
			var csv_content = ReadCsv();
			var birthdays = LoadList(csv_content);

			// Sort the list so closest birthday is at the bottom.
			foreach (var birthday in birthdays.OrderByDescending(bday => bday.RemainingTime()))
			{
				Console.WriteLine(birthday.ToString() + "\n");
			}
		}

		// Read the .csv and parse it into a string,string Dictionary.
		static Dictionary<string, string> ReadCsv()
		{
			// .csv file
			// Put a .csv file you want to get birthdays from in this format:
			//	
			//		day1/month1,name1
			//		day2/month2,name2
			//		...
			string filePath = $"{AppDomain.CurrentDomain.BaseDirectory}/birthdays.csv";

			var birthdays = new Dictionary<string, string>();

			using (var reader = new StreamReader(filePath))
			{
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine().Split(',');

					// line[0] is the date, line[1] is the name of the person
					birthdays.Add(line[0], line[1]);
				}
			}

			return birthdays;
		}

		// Using the dictionary we parsed earlier, we are converting the first string in the dictionary (line[0]) to a DateTime object.
		// Then we pass the second string (line[1]) as the name to a birthday object.
		// See Birthday.cs for further detail.
		static List<Birthday> LoadList(Dictionary<string, string> csv)
		{
			var birthdays = new List<Birthday>();

			foreach (var kvp in csv)
			{
				DateTime date = DateTime.ParseExact(kvp.Key + $"/{DateTime.Today.Year}", "dd/MM/yyyy", CultureInfo.GetCultureInfo("tr-TR"));

				birthdays.Add(new Birthday(date, kvp.Value));
			}

			return birthdays;

		}
	}
}
