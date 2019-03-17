using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Core = Fritz.CheerGraffiti.Core;


namespace Test.CheerGraffiti.ProjectProcessor
{

	public class GivenAProjectWithCheers : BaseFixture
	{

		private const string File1 = "TestFile1.cs";

		public GivenAProjectWithCheers()
		{
			ExtractTestFilesResource(File1);
		}

		[Fact]
		public void WhenAnalyzingFiles_ShouldFindCheers()
		{

			var sut = new Core.ProjectProcessor();
			var cheersFound = sut.GetCheersForFiles(new[] { File1 });

			Assert.NotNull(cheersFound);
			Assert.Single(cheersFound);
			Assert.Single(cheersFound.First().cheers);

			var foundCheer = cheersFound.First().cheers.First();
			Assert.Equal("csharpfritz", foundCheer.ViewerName);
			Assert.Equal(100, foundCheer.Bits);

		}


	}
}
