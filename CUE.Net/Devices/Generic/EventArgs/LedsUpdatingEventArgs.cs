// ---------------------------------------------------------
// Copyrights (c) 2014-2017 Seditio 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Collections.Generic;

namespace CUE.Net.Devices.Generic.EventArgs
{
    /// <summary>
    ///   Represents the information supplied with an <see cref="ICueDevice.LedsUpdating" />-event.
    /// </summary>
    public class LedsUpdatingEventArgs : System.EventArgs
    {
        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="LedsUpdatingEventArgs" /> class.
        /// </summary>
        /// <param name="updatingLeds">The updating leds.</param>
        public LedsUpdatingEventArgs(ICollection<LedUpateRequest> updatingLeds) => UpdatingLeds = updatingLeds;

        #endregion

        #region Properties & Fields

        /// <summary>
        ///   Gets a list of <see cref="LedUpateRequest" /> from the updating leds.
        /// </summary>
        public ICollection<LedUpateRequest> UpdatingLeds { get; }

        #endregion
    }
}