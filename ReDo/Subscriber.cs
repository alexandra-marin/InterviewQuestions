using System;

namespace Redo
{
	public class Subscriber : IObserver<Publisher>
	{
		#region IObserver implementation
		public void OnCompleted ()
		{
			throw new NotImplementedException ();
		}
		public void OnError (Exception error)
		{
			throw new NotImplementedException ();
		}
		public void OnNext (Publisher value)
		{
			Console.WriteLine ("Received!");
		}
		#endregion
	}

}

