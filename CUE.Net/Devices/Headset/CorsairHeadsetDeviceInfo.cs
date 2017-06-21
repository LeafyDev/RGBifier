using CUE.Net.Devices.Generic;
using CUE.Net.Native;

namespace CUE.Net.Devices.Headset
{
    /// <summary>
    /// Represents specific information for a CUE headset.
    /// </summary>
    public class CorsairHeadsetDeviceInfo : GenericDeviceInfo
    {
        #region Constructors

        /// <summary>
        /// Internal constructor of managed <see cref="CorsairHeadsetDeviceInfo" />.
        /// </summary>
        /// <param name="nativeInfo">The native <see cref="_CorsairDeviceInfo" />-struct</param>
        internal CorsairHeadsetDeviceInfo(_CorsairDeviceInfo nativeInfo)
            : base(nativeInfo)
        { }

        #endregion
    }
}
