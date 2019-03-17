using System.Collections.Generic;

namespace Fritz.CheerGraffiti.Core.Formatters
{
	public interface IReportFormatter
	{

		void FormatReport(IEnumerable<(string fileName, IEnumerable<Cheer> cheers)> cheerReport, string outputFileName);

	}
}