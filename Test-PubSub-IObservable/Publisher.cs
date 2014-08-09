using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestPubSubIObservable
{

	public class Publisher<T> : IObservable<T>
	{
		private List<IObserver<T>> observers = new List<IObserver<T>>();

		public Publisher() { }

		public IDisposable Subscribe (IObserver<T> observer)
		{
			if (observer != null && !observers.Contains(observer)) 
			{
				observers.Add (observer);
			}

			return new DisposableSubscriber (observer, observers);
		}

		protected void Notify(T obj)
		{
			List<Task> notifications = new List<Task>();
			foreach (IObserver<T> observer in observers)
			{
				Task notification = new Task (() => observer.OnNext (obj));
				notification.Start ();
				notifications.Add (notification);
			}
			Task.WaitAll (notifications.ToArray()); //wait for all tasks to complete
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
	
}