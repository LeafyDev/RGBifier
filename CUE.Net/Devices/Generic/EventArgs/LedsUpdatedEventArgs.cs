// ---------------------------------------------------------
// Copyrights (c) 2014-2017 Seditio 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Collections.Generic;

namespace CUE.Net.Devices.Generic.EventArgs
{
    /// <summary>
    ///   Represents the information supplied with an <see cref="ICueDevice.LedsUpdated" />-event.
    /// </summary>
    public class LedsUpdatedEventArgs : System.EventArgs
    {
        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="LedsUpdatedEventArgs" /> class.
        /// </summary>
        /// <param name="updatedLeds">The updated leds.</param>
        public LedsUpdatedEventArgs(IEnumerable<LedUpateRequest> updatedLeds) => UpdatedLeds = updatedLeds;

        #endregion

        #region Properties & Fields

        /// <summary>
        ///   Gets a list of <see cref="LedUpateRequest" /> from the updated leds.
        /// </summary>
        public IEnumerable<LedUpateRequest> UpdatedLeds { get; }

        #endregion
    }
}