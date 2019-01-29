using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fritz.CheerGraffiti.Core
{
	public class CodeAnalyzer
	{

		public IEnumerable<Cheer> LocateCheersInFileContents(string fileContents)
		{

			var tree = CSharpSyntaxTree.ParseText(fileContents);
			var root = tree.GetCompilationUnitRoot();
			var commentNodes = root.DescendantTrivia().Where(node => node.Kind() == SyntaxKind.MultiLineCommentTrivia || node.Kind() == SyntaxKind.SingleLineCommentTrivia).ToArray();

			if (!commentNodes.Any())
			{
				return new Cheer[] { };
			}

			var outCheers = new List<Cheer>();

			foreach (var node in commentNodes.Where(n => n.ToString().ToLowerInvariant().Contains("cheer")))
			{

				outCheers.Add(new Cheer(node.ToString()));

			}

			return outCheers;

		}

	}
}
