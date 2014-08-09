using System.Collections.Generic;
using System.Linq;

namespace TestPubSubIObservable
{
	public class PubSubTest
	{
		public static void Main ()
		{
			Magazine pub = new Magazine();

			Enumerable.Range (0, 10000).ToList().ForEach (x => pub.Subscribe(new BadSubscriber()));

			pub.Notify ();
		}
	}
}

