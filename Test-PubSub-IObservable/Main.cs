using System;
using System.Collections.Generic;

namespace TestPubSubIObservable
{
	public class PubSubTest
	{
		public static void Main ()
		{
			Magazine pub = new Magazine();

			Subscriber sub1 = new Subscriber();
			Subscriber sub2 = new Subscriber();

			pub.Subscribe (sub1);
			pub.Subscribe (sub2);

			pub.Notify ();
		}
	}


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

	public class Publisher<T> : IObservable<T>
	{
		private List<IObserver<T>> observers;
		public Publisher()
		{
			observers = new List<IObserver<T>>();
		}

		public IDisposable Subscribe (IObserver<T> observer)
		{
			observers.Add (observer);
			return new DisposableSubscriber (observer, observers);
		}

		protected void Notify(T obj)
		{
			foreach (IObserver<T> observer in observers)
			{
				observer.OnNext(obj);
			}
		}

		private class DisposableSubscriber : IDisposable
		{
			IObserver<T> obs;
			List<IObserver<T>> observers;

			public DisposableSubscriber(IObserver<T> obs, List<IObserver<T>> observers)
			{
				this.obs = obs;
				this.observers = observers;
			}

			#region IDisposable implementation

			public void Dispose ()
			{
				if (obs != null && observers.Contains(obs))
					observers.Remove (obs);
			}

			#endregion
		}
	}

	public class Magazine : Publisher<Magazine>
	{
		public void Notify()
		{
			Console.WriteLine ("New issue is out!");
			base.Notify (this);
		}
	}
}

