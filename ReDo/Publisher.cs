using System;
using System.Collections.Generic;

namespace Redo
{
	public class Publisher : IObservable<Publisher>
	{
		List<IObserver<Publisher>> observers = new List<IObserver<Publisher>>();


		public void Publish ()
		{
			foreach (var observer in observers) 
			{
				observer.OnNext (this);
			}
		}

		#region IObservable implementation

		public IDisposable Subscribe (IObserver<Publisher> observer)
		{
			observers.Add (observer);
			return new DisposableSubscriber (observer, observers);
		}

		private class DisposableSubscriber : IDisposable
		{
			IObserver<Publisher> obs;
			List<IObserver<Publisher>> observers;

			public DisposableSubscriber(IObserver<Publisher> obs, List<IObserver<Publisher>> observers)
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

		#endregion
	}

}

