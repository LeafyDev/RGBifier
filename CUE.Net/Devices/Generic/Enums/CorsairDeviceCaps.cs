// ---------------------------------------------------------
// Copyrights (c) 2014-2017 Seditio 🍂 All rights reserved.
// ---------------------------------------------------------

using System;

namespace CUE.Net.Devices.Generic.Enums
{
    /// <summary>
    ///   Contains list of device capabilities
    /// </summary>
    [Flags]
    public enum CorsairDeviceCaps
    {
        /// <summary>
        ///   For devices that do not support any SDK functions
        /// </summary>
        None = 0,

        /// <summary>
        ///   For devices that has controlled lighting
        /// </summary>
        Lighting = 1
    }
}