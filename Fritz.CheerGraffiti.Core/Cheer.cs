using System;
using System.Text.RegularExpressions;

namespace Fritz.CheerGraffiti.Core
{

	// Cheer 200 cpayette 29/01/19
	// Cheer 181 magnus10 29/01/19 

	public class Cheer
	{

		private static readonly Regex ViewerNameRegex = new Regex(@"([a-zA-Z0-9_]{4,25})");
		private static readonly Regex BitsRegex = new Regex(@"\s(\d{3,})\s");

		public Cheer(string cheerText)
		{

			cheerText = cheerText.Trim().Replace("// ", "");
			cheerText = cheerText.Trim().Replace("* ", "");

			cheerText = cheerText.Replace("cheer", "").Replace("Cheer", "");
			Bits = int.Parse(BitsRegex.Match(cheerText).Captures[0].Value);

			cheerText = cheerText.Replace(Bits.ToString(), "");
			ViewerName = ViewerNameRegex.Match(cheerText).Captures[0].Value;

			cheerText = cheerText.Replace(ViewerName, "").Trim();
			if (DateTime.TryParseExact(cheerText, "d/M/yy", null, System.Globalization.DateTimeStyles.None, out var thisDate))
				Date = thisDate;

			if (DateTime.TryParseExact(cheerText, "M/d/yy", null, System.Globalization.DateTimeStyles.None, out var americanDate))
				Date = americanDate;

			if (DateTime.TryParseExact(cheerText, "MMMM dd, yyyy", null, System.Globalization.DateTimeStyles.None, out var longDate))
				Date = longDate;


		}

		/// <summary>
		/// User who cheered
		/// </summary>
		public string ViewerName { get; set; }

		/// <summary>
		/// Number of bits cheered
		/// </summary>
		public int Bits { get; set; }

		/// <summary>
		/// Date of the cheer
		/// </summary>
		public DateTime Date { get; set; }

		/// <summary>
		/// File containing the cheer
		/// </summary>
		public string FileName { get; set; }

		/// <summary>
		/// Repository containing the project with the cheer
		/// </summary>
		public string Repository { get; set; }

	}
}
