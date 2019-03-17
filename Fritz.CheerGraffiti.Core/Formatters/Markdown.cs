using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Fritz.CheerGraffiti.Core.Formatters
{

	public class Markdown : IReportFormatter
	{
		public void FormatReport(IEnumerable<(string fileName, IEnumerable<Cheer> cheers)> cheerReport, string outputFileName)
		{

			var sw = new StreamWriter(outputFileName);

			sw.AutoFlush = true;
			sw.WriteLine("# Supporters of this project");
			sw.WriteLine();

			var cheerSummary = SummarizeCheers(cheerReport)
				.OrderByDescending(s => s.TotalCheers);

			foreach (var cheer in cheerSummary)
			{
				sw.WriteLine($"  * {cheer.UserName}  - {cheer.TotalCheers}");
			}

			sw.Flush();
			sw.Dispose();

		}

		public IEnumerable<CheerSummary> SummarizeCheers(IEnumerable<(string fileName, IEnumerable<Cheer> cheers)> cheerReport)
		{
			return cheerReport.SelectMany(r => r.cheers)
				.GroupBy(c => c.ViewerName.ToLowerInvariant())
				.Select(g => new CheerSummary
				{
					UserName = g.Key,
					TotalCheers = g.Sum(c => c.Bits)
				});
		}

		public class CheerSummary {

			public string UserName { get; set; }

			public int TotalCheers { get; set; }

		}

	}

}
