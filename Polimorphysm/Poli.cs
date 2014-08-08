using System;

namespace Polimorphysm
{
	public class Poli
	{
		public static void Main ()
		{
			Telephone t1 = new Telephone ();
			Telephone t2 = new MobilePhone ();

			t1.Ring ();
			t2.Ring ();
		}
	}

	public class Telephone
	{
		public virtual void Ring()
		{
			Console.WriteLine ("Ring!");
		}
	}

	public class MobilePhone : Telephone
	{
		public override void Ring ()
		{
			Console.WriteLine ("Buzz!");
		}
	}
}

