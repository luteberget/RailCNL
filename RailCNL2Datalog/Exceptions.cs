﻿using System;

namespace RailCNL2Datalog
{
		[Serializable]
		public class UnsupportedExpressionException : Exception
		{
			/// <summary>
			/// Initializes a new instance of the <see cref="T:UnsupportedExpressionException"/> class
			/// </summary>
			public UnsupportedExpressionException ()
			{
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="T:UnsupportedExpressionException"/> class
			/// </summary>
			/// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
			public UnsupportedExpressionException (string message) : base (message)
			{
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="T:UnsupportedExpressionException"/> class
			/// </summary>
			/// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
			/// <param name="inner">The exception that is the cause of the current exception. </param>
			public UnsupportedExpressionException (string message, Exception inner) : base (message, inner)
			{
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="T:UnsupportedExpressionException"/> class
			/// </summary>
			/// <param name="context">The contextual information about the source or destination.</param>
			/// <param name="info">The object that holds the serialized object data.</param>
			protected UnsupportedExpressionException (System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base (info, context)
			{
			}
		}

	[Serializable]
	public class LexerException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:LexerException"/> class
		/// </summary>
		public LexerException ()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:LexerException"/> class
		/// </summary>
		/// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
		public LexerException (string message) : base (message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:LexerException"/> class
		/// </summary>
		/// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
		/// <param name="inner">The exception that is the cause of the current exception. </param>
		public LexerException (string message, Exception inner) : base (message, inner)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:LexerException"/> class
		/// </summary>
		/// <param name="context">The contextual information about the source or destination.</param>
		/// <param name="info">The object that holds the serialized object data.</param>
		protected LexerException (System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base (info, context)
		{
		}
	}
}

