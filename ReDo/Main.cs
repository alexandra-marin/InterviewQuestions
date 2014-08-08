using System;

namespace Redo
{
	public class PubSub
	{
		public static void Main ()
		{
			Publisher pub = new Publisher ();

			Subscriber sub1 = new Subscriber ();
			Subscriber sub2 = new Subscriber ();

			pub.Subscribe (sub1);
			pub.Subscribe (sub2);

			pub.Publish ();
		}
	}
}

