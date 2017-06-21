﻿// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

using System;

namespace CUE.Net.Devices.Generic.EventArgs
{
    /// <summary>
    /// Represents the information supplied with an <see cref="ICueDevice.Exception"/>-event.
    /// </summary>
    public class ExceptionEventArgs : System.EventArgs
    {
        #region Properties & Fields

        /// <summary>
        /// Gets the exception which is responsible for the event-call.
        /// </summary>
        public Exception Exception { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionEventArgs"/> class.
        /// </summary>
        /// <param name="exception">The exception which is responsible for the event-call.</param>
        public ExceptionEventArgs(Exception exception) => Exception = exception;

        #endregion
    }
}
