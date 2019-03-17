using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Core = Fritz.CheerGraffiti.Core;

namespace Test.CheerGraffiti.MarkdownFormatter
{
	public class GivenMultipleViewers
	{

		[Fact]
		public void ShouldSummarize()
		{

			var testData = new List<(string fileName, IEnumerable<Core.Cheer>)>
			{
				("Test1.cs", new [] {
					new Core.Cheer {ViewerName="Jeff", Bits=100},
					new Core.Cheer {ViewerName="RobertTables", Bits=200},
					new Core.Cheer {ViewerName="pakmanjr", Bits=300},
					new Core.Cheer {ViewerName="jeff", Bits=150},
				})
			};

			var sut = new Core.Formatters.Markdown();
			var results = sut.SummarizeCheers(testData);

			Assert.NotEmpty(results);
			Assert.Equal(3, results.Count());
			Assert.Equal(250, results.First(s => s.UserName == "jeff").TotalCheers);


		}

	}
}
