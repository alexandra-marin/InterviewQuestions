using System;

namespace TestPubSubIObservable
{

	public class Magazine : Publisher<Magazine>
	{
		public void Notify()
		{
			Console.WriteLine ("New issue is out!");
			base.Notify (this);
		}
	}
}
