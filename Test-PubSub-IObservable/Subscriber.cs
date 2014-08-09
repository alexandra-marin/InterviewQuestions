using System;
using System.Threading;

namespace TestPubSubIObservable
{
	public class Subscriber : IObserver<Magazine>
	{
		public void OnCompleted ()
		{
			throw new NotImplementedException ();
		}
		public void OnError (Exception error)
		{
			throw new NotImplementedException ();
		}
		public void OnNext (Magazine value)
		{
			Console.WriteLine ("Sub received!");
		}
	}
	public class BadSubscriber : IObserver<Magazine>
	{
		public void OnCompleted ()
		{
			throw new NotImplementedException ();
		}
		public void OnError (Exception error)
		{
			throw new NotImplementedException ();
		}
		public void OnNext (Magazine value)
		{
			Console.WriteLine ("Sub received!");
			Thread.Sleep (500);
			Console.WriteLine ("Sub finished");
		}
	}
}
