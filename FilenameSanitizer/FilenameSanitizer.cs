using System;

namespace FilenameSanitizer
{
    public class FilenameSanitizer
	{
		public string RemoveIllegalCharacters(string filename)
		{
			if (string.IsNullOrEmpty(filename))
			{
				throw new ArgumentException("Filename must not be null or empty", nameof(filename));
			}

			var invalidChars = Path.GetInvalidFileNameChars();
			var sb = new StringBuilder();

			foreach (var @char in filename)
			{
				if (!invalidChars.Contains(@char))
				{
					sb.Append(@char);
				}
			}

			return sb.ToString();
		}
	}
}
