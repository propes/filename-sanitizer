using System;
using Xunit;

namespace FilenameSanitizer.tests
{
    [TestFixture]
	public class FilenameSanitizerTests
	{
		[TestCase(null)]
		[TestCase("")]
		public void ShouldThrowException_WhenFilenameIsNullOrEmpty(string input)
		{
			var sanitiser = new FilenameSanitiser();

			Assert.Throws<ArgumentException>(() => sanitiser.RemoveIllegalCharacters(input));
		}

		[TestCase(" ", " ")]
		[TestCase("file.txt", "file.txt")]
		[TestCase("my file.txt", "my file.txt")]
		[TestCase("file_v1.txt", "file_v1.txt")]
		[TestCase("file<.txt", "file.txt")]
		[TestCase("file>.txt", "file.txt")]
		[TestCase("file:.txt", "file.txt")]
		[TestCase("file\".txt", "file.txt")]
		[TestCase("file/.txt", "file.txt")]
		[TestCase("file\\.txt", "file.txt")]
		[TestCase("file|.txt", "file.txt")]
		[TestCase("file?.txt", "file.txt")]
		[TestCase("file*.txt", "file.txt")]
		[TestCase("\"M\"\\a/ry h*ad:>< a\\/:?\"|\n\t litt|le la\"mb_v1.?file", "Mary had a little lamb_v1.file")]
		public void ShouldRemoveIllegalCharacters(string input, string expected)
		{
			var sanitiser = new FilenameSanitiser();

			var actual = sanitiser.RemoveIllegalCharacters(input);

			Assert.That(actual, Is.EqualTo(expected));
		}
	}
}
