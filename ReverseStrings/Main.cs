using System;
using System.Text;

namespace ReverseStrings
{
	public class ReverseStrings
	{
		public static void Main ()
		{
			String str = "...The... quick,,, brown     fox...";
			Reverse (str);
		}

		static void Reverse (string input)
		{
			int index = 0;
			char[] allChars = input.ToCharArray ();
			string[] words = input.Split (new Char[] {' ', ',', '.'});
			StringBuilder output = new StringBuilder ();

			foreach (var word in words) 
			{
				char[] chars = word.ToCharArray ();
				Array.Reverse (chars);

				output.Append (chars);


				index += word.Length;

				if (index < allChars.Length) 
				{
					output.Append (allChars [index]);
					index++;
				}
			}

			Console.WriteLine (input + "\n" + output);
		}
	}
}

