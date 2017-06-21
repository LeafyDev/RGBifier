// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

using System;
using CUE.Net.Devices.Generic.Enums;

namespace CUE.Net.Exceptions
{
    /// <summary>
    /// Represents an exception thrown by the CUE.
    /// </summary>
    public class CUEException : Exception
    {
        #region Properties & Fields

        /// <summary>
        /// Gets the <see cref="CorsairError" /> provided by CUE.
        /// </summary>
        public CorsairError Error { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CUEException"/> class.
        /// </summary>
        /// <param name="error">The <see cref="CorsairError" /> provided by CUE, which leads to this exception.</param>
        public CUEException(CorsairError error)
        {
            this.Error = error;
        }

        #endregion
    }
}
