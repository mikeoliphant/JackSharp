using System;

namespace JackSharp.Events
{
	/// <summary>
	/// Info message event arguments.
	/// </summary>
	public sealed class InfoEventArgs : EventArgs
	{
		/// <summary>
		/// Gets the error message.
		/// </summary>
		/// <value>Info message.</value>
		public string Info { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="JackSharp.Events.InfoEventArgs"/> class.
		/// </summary>
		/// <param name="err">Info message.</param>
		public InfoEventArgs (string info)
		{
			Info = info;
		}
	}
}