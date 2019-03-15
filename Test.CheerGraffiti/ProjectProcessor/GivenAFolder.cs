using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Core = Fritz.CheerGraffiti.Core;

namespace Test.CheerGraffiti.ProjectProcessor
{
	public class GivenAFolder
	{
		private DirectoryInfo _MyEmptyFolder;
		private readonly DirectoryInfo _ThisSourceFolder;

		public GivenAFolder()
		{

			_MyEmptyFolder = new DirectoryInfo("emptyFolder");
			if (!_MyEmptyFolder.Exists) _MyEmptyFolder.Create();

			var assemblyFolder = new FileInfo(GetType().Assembly.Location).Directory;
			while (!assemblyFolder.GetFiles("*.csproj").Any())
			{
				assemblyFolder = assemblyFolder.Parent;
			}
			_ThisSourceFolder = assemblyFolder;

		}

		[Fact]
		public async Task WhenNoProjectPresent_ShouldReturnNoFiles()
		{

			var sut = new Core.ProjectProcessor();
			var results = await sut.IdentifyFilesToProcess(_MyEmptyFolder.FullName);

			Assert.Empty(results);

		}

		[Fact]
		public async Task AndSubmittingRelativePath_WhenNoProjectPresent_ShouldReturnNoFiles()
		{

			var sut = new Core.ProjectProcessor();
			var results = await sut.IdentifyFilesToProcess(_MyEmptyFolder.Name);

			Assert.Empty(results);

		}

		[Fact(Skip ="Need to setup to run from the proper location on disk for relative testing")]
		public async Task AndSubmittingRelativePath_WhenProjectPresent_ShouldReturnFiles()
		{

			var sut = new Core.ProjectProcessor();
			var results = await sut.IdentifyFilesToProcess(_ThisSourceFolder.Name);

			Assert.NotEmpty(results);

		}

		[Fact]
		public async Task WhenProjectPresent_ShouldReturnFiles()
		{

			var sut = new Core.ProjectProcessor();
			var results = await sut.IdentifyFilesToProcess(_ThisSourceFolder.FullName);

			Assert.NotEmpty(results);

		}

	}
}
