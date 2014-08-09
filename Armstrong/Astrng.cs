using System;
using System.Linq;

namespace Armstrong
{
	public class ArmstrongNumbers
	{
		public static void Main ()
		{
			double number = 153;

			Console.WriteLine (IsArmstrong (number));
		}

		static bool IsArmstrong (double number)
		{
			int index = number.ToString ().Length;
			double sum = 0;

			foreach (char digit in number.ToString ().ToCharArray()) 
			{
				sum += Math.Pow(Int32.Parse (digit.ToString()), index);
			}

			return Math.Abs(sum - number) < double.Epsilon;
		}
	}
}

