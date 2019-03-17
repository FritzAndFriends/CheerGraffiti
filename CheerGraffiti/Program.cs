using System;
using System.IO;
using Fritz.CheerGraffiti.Core;
using Fritz.CheerGraffiti.Core.Formatters;

namespace CheerGraffiti
{

	class Program
	{

		// Cheer 100 cpayette 15/3/19 
		// Cheer 100 electrichavoc 15/3/19 
		// Cheer 200 johanb 15/3/19 
		// Cheer 300 motownandy 15/3/19 

		/// <param name="pathToProject">An option whose argument is parsed as a bool</param>
		static void Main(string pathToProject)
		{

			Console.WriteLine($"The value for --path-to-project is: {pathToProject}");

			var processor = new ProjectProcessor();
			var files = processor.IdentifyFilesToProcess(pathToProject);
			var report = processor.GetCheersForFiles(files);

			new Markdown().FormatReport(report, "summarize.md");


		}

	}

}
