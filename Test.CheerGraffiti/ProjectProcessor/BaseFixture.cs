using System.IO;


namespace Test.CheerGraffiti.ProjectProcessor
{
	public class BaseFixture
	{
		protected void ExtractTestFilesResource(string fileName, string targetFolder = "")
		{

			var targetFileName = fileName;
			if (!string.IsNullOrEmpty(targetFolder))
				targetFileName = Path.Combine(targetFolder, fileName);
			if (File.Exists(fileName)) return;

			var stream = GetType().Assembly.GetManifestResourceStream("Test.CheerGraffiti.TestFiles." + fileName);
			var sw = new StreamWriter(targetFileName)
			{
				AutoFlush = true
			};
			var sr = new StreamReader(stream);

			sw.Write(sr.ReadToEnd());
			sw.Close();
			sw.Dispose();
			sr.Dispose();

		}

	}
}
