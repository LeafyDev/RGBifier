﻿// ---------------------------------------------------------
// Copyrights (c) 2014-2017 Seditio 🍂 All rights reserved.
// ---------------------------------------------------------

using CUE.Net.Devices.Generic.Enums;

namespace CUE.Net.Devices.Generic
{
    /// <summary>
    ///   Represents a request to update a led.
    /// </summary>
    public class LedUpateRequest
    {
        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="LedUpateRequest" /> class.
        /// </summary>
        /// <param name="ledId">The id of the led to update.</param>
        /// <param name="color">The requested color of the led.</param>
        public LedUpateRequest(CorsairLedId ledId, CorsairColor color)
        {
            LedId = ledId;
            Color = color;
        }

        #endregion

        #region Properties & Fields

        /// <summary>
        ///   Gets the id of the led to update.
        /// </summary>
        public CorsairLedId LedId { get; }

        /// <summary>
        ///   Gets the requested color of the led.
        /// </summary>
        public CorsairColor Color { get; set; }

        #endregion
    }
}