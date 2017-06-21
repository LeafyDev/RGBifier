// ---------------------------------------------------------
// Copyrights (c) 2014-2017 Seditio 🍂 All rights reserved.
// ---------------------------------------------------------

using CUE.Net.Devices.Generic;
using CUE.Net.Native;

namespace CUE.Net.Devices.Mousemat
{
    /// <summary>
    ///   Represents specific information for a CUE Mousemat.
    /// </summary>
    public class CorsairMousematDeviceInfo : GenericDeviceInfo
    {
        #region Constructors

        /// <summary>
        ///   Internal constructor of managed <see cref="CorsairMousematDeviceInfo" />.
        /// </summary>
        /// <param name="nativeInfo">The native <see cref="_CorsairDeviceInfo" />-struct</param>
        internal CorsairMousematDeviceInfo(_CorsairDeviceInfo nativeInfo) : base(nativeInfo) { }

        #endregion
    }
}