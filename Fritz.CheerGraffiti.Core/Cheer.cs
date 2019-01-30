using System;
using System.Text;
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

			cheerText = cheerText.Replace("cheered", "").Replace("Cheered", "");
			cheerText = cheerText.Replace("cheer", "").Replace("Cheer", "");
			var bitsCapture = BitsRegex.Match(cheerText).Captures[0];
			Bits = int.Parse(bitsCapture.Value);

			//remove only bits and ignore same number in viewerName
			var startIndexOfBits = bitsCapture.Index;
			var sb = new StringBuilder(cheerText);
			sb.Remove(startIndexOfBits, bitsCapture.Value.Length);
			cheerText = sb.ToString();

			ViewerName = ViewerNameRegex.Match(cheerText).Captures[0].Value;

			cheerText = cheerText.Replace(ViewerName, "").Trim();
			cheerText = cheerText.Replace("on ", "");
			//"11/3/19" -> November 3rd 2019
			if (DateTime.TryParseExact(cheerText, "MM/d/yy", new System.Globalization.CultureInfo("en-US"), System.Globalization.DateTimeStyles.None, out var americanNonPaddedDayDate))
			{
				Date = americanNonPaddedDayDate;
			}
			//"1/01/19" -> January 1st 2019
			else if (DateTime.TryParseExact(cheerText, "d/MM/yy", null, System.Globalization.DateTimeStyles.None, out var nonPaddedDayDate))
			{
				Date = nonPaddedDayDate;
			}
			else if (DateTime.TryParseExact(cheerText, "d/M/yy", null, System.Globalization.DateTimeStyles.None, out var thisDate))
			{
				Date = thisDate;
			}
			else if (DateTime.TryParseExact(cheerText, "M/d/yy", null, System.Globalization.DateTimeStyles.None, out var americanDate))
			{
				Date = americanDate;
			}
			//"January 29, 2019" or "November 29, 2018" on non english systems
			else if (DateTime.TryParseExact(cheerText, "MMMM dd, yyyy", new System.Globalization.CultureInfo("en-US"), System.Globalization.DateTimeStyles.None, out var americanLongDate))
			{
				Date = americanLongDate;
			}
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
