using System;
using System.Runtime.InteropServices;
using CUE.Net.Devices.Generic.Enums;
using CUE.Net.Native;

namespace CUE.Net.Devices.Generic
{
    /// <summary>
    /// Represents generic information about a CUE device.
    /// </summary>
    public class GenericDeviceInfo : IDeviceInfo
    {
        #region Properties & Fields

        /// <summary>
        /// Gets the device type. (<see cref="CUE.Net.Devices.Generic.Enums.CorsairDeviceType" />)
        /// </summary>
        public CorsairDeviceType Type { get; }

        /// <summary>
        /// Gets the device model (like “K95RGB”).
        /// </summary>
        public string Model { get; }

        /// <summary>
        /// Get a flag that describes device capabilities. (<see cref="CUE.Net.Devices.Generic.Enums.CorsairDeviceCaps" />)
        /// </summary>
        public CorsairDeviceCaps CapsMask { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Internal constructor of managed <see cref="GenericDeviceInfo"/>.
        /// </summary>
        /// <param name="nativeInfo">The native <see cref="_CorsairDeviceInfo" />-struct</param>
        internal GenericDeviceInfo(_CorsairDeviceInfo nativeInfo)
        {
            this.Type = nativeInfo.type;
            this.Model = nativeInfo.model == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeInfo.model);
            this.CapsMask = (CorsairDeviceCaps)nativeInfo.capsMask;
        }

        #endregion
    }
}
