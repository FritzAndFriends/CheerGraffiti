using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fritz.CheerGraffiti.Core
{

	public class ProjectProcessor
	{

		/// <summary>
		/// Identify the C# files to read and pass on to the Cheer processor
		/// </summary>
		/// <param name="projectFolder"></param>
		/// <returns></returns>
		public IEnumerable<string> IdentifyFilesToProcess(string projectFolder)
		{

			var thisFolder = new DirectoryInfo(projectFolder);

			return thisFolder.GetFiles("*.cs", SearchOption.AllDirectories).Select(f => f.Name);

		}

		public IEnumerable<(string filename, IEnumerable<Cheer> cheers)> GetCheersForFiles(IEnumerable<string> files)
		{

			return null;

		}


	}

}
