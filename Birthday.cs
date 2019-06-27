using System;

namespace BirthdayCS
{
	// This class is made to contain information about the birthday date and person.
	public class Birthday
	{
		public DateTime BirthDate;
		public string Name = "";

		public Birthday(DateTime birthdate, string name)
		{
			this.BirthDate = birthdate;
			this.Name = name;
		}

		// We use this function to determine which birthday is the closest
		public TimeSpan RemainingTime()
		{
			// If birthdate is in this year, just subtract today from it.
			if (this.BirthDate >= DateTime.Today)
			{
				var remaining = this.BirthDate.Subtract(DateTime.Now);
				return remaining;
			}
			// If it is not, add 365 days and then subtract today.
			else
			{
				var remaining = this.BirthDate.AddYears(1).Subtract(DateTime.Now);
				return remaining;
			}
		}

		public override string ToString()
		{
			// This is a dirty way of converting a TimeSpan into a readable string.
			// There is 100% a better way to do this.
			var remainingTime = $"{this.RemainingTime().Days - 1} day(s), {this.RemainingTime().Hours} hour(s) and {this.RemainingTime().Minutes} minute(s)";

			return $"{this.Name}'s Birthday in : {this.BirthDate.ToLongDateString()}\nRemaining time : {remainingTime}";
		}
	}
}
