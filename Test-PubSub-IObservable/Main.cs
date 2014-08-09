using System;
using System.Collections.Generic;

namespace TestPubSubIObservable
{
	public class PubSubTest
	{
		public static void Main ()
		{
			Magazine pub = new Magazine();

			BadSubscriber sub1 = new BadSubscriber();
			Subscriber sub2 = new Subscriber();

			pub.Subscribe (sub1);
			pub.Subscribe (sub2);

			pub.Notify ();
		}
	}
}

