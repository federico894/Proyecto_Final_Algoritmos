/*
 * Created by SharpDevelop.
 * User: fede
 * Date: 13/5/2025
 * Time: 12:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.Serialization;

namespace Proyecto_Final_Algoritmos.Exceptions
{
	/// <summary>
	/// Description of Exception.
	/// </summary>
	public class Exception : Exception
	{
		public Exception()
		{
		}

	 	public Exception(string message) : base(message)
		{
		}

		public Exception(string message, Exception innerException) : base(message, innerException)
		{
		}

		// This constructor is needed for serialization.
		protected Exception(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}