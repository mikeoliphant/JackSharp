using System;

namespace JackSharp.Events
{
	/// <summary>
	/// Error message event arguments.
	/// </summary>
	public sealed class ErrorEventArgs : EventArgs
	{
		/// <summary>
		/// Gets the error message.
		/// </summary>
		/// <value>Error message.</value>
		public string Error { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="JackSharp.Events.ErrorEventArgs"/> class.
		/// </summary>
		/// <param name="err">Error message.</param>
		public ErrorEventArgs (string err)
		{
			Error = err;
		}
	}
}
