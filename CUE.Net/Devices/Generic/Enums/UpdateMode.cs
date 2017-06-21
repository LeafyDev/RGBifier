﻿// ---------------------------------------------------------
// Copyrights (c) 2014-2017 Seditio 🍂 All rights reserved.
// ---------------------------------------------------------

namespace CUE.Net.Devices.Generic.Enums
{
    /// <summary>
    ///   Contains list of available update modes.
    /// </summary>
    public enum UpdateMode
    {
        /// <summary>
        ///   The device will not perform automatic updates. Updates will only occur if <see cref="ICueDevice.Update" /> is called.
        /// </summary>
        Manual,

        /// <summary>
        ///   The device will perform automatic updates at the rate set in <see cref="CueSDK.UpdateFrequency" />.
        /// </summary>
        Continuous
    }
}