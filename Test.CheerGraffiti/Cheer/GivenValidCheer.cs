using System;
using Xunit;
using Core = Fritz.CheerGraffiti.Core;

namespace Test.CheerGraffiti.Cheer
{
	public class GivenValidCheer
	{

		// Cheer 100 lannonbr 29/1/19 

		[Theory()]
		[InlineData("// Cheer 200 cpayette 29/01/19", 2019, 1, 29)]
		[InlineData("// Cheer 200 cpayette 12/25/19", 2019, 12, 25)]
		[InlineData("// Cheer 181 magnus10 1/01/19", 2019, 1, 1)]
		[InlineData("// Cheer 181 magnus10 11/3/19", 2019, 11, 3)]
		[InlineData("// Cheer 181 CleverUser123 January 29, 2019", 2019, 1, 29)]
		[InlineData("// Cheer 181 420i 29/01/19", 2019, 1, 29)]
		// [InlineData("// restarted cheered 500 on November 29, 2018", 2018, 11, 29)]
		public void ShouldParseDate(string validCheer, int year, int month, int day)
		{

			// Arrange
			var expectedDate = new DateTime(year, month, day);

			// Act
			var sut = new Core.Cheer(validCheer);

			// Assert
			Assert.Equal(expectedDate, sut.Date);

		}

		[Theory()]
		[InlineData("// Cheer 200 cpayette 29/01/19", "cpayette")]
		[InlineData("// Cheer 181 magnus10 29/01/19", "magnus10")]
		[InlineData("// Cheer 181 magnus2000 29/01/19", "magnus2000")]
		[InlineData("// Cheer 181 CleverUser123 29/01/19", "CleverUser123")]
		[InlineData("// Cheer 181 420i 29/01/19", "420i")]
		[InlineData("// Cheer 181 8675309 29/01/19", "8675309")]
		[InlineData("// restarted cheered 500 on November 29, 2018", "restarted")]
		public void ShouldParseViewer(string validCheer, string expectedViewer)
		{

			// Arrange

			// Act
			var sut = new Core.Cheer(validCheer);

			// Assert
			Assert.Equal(expectedViewer, sut.ViewerName);

		}

		[Theory()]
		[InlineData("// Cheer 200 cpayette 29/01/19", 200)]
		[InlineData("// Cheer 181 magnus10 29/01/19", 181)]
		[InlineData("// Cheer 181 CleverUser123 29/01/19", 181)]
		[InlineData("// Cheer 181 420i 29/01/19", 181)]
		public void ShouldParseValue(string validCheer, int expectedValue)
		{

			// Arrange

			// Act
			var sut = new Core.Cheer(validCheer);

			// Assert
			Assert.Equal(expectedValue, sut.Bits);

		}

	}
}
