﻿// ---------------------------------------------------------
// Copyrights (c) 2014-2017 Seditio 🍂 All rights reserved.
// ---------------------------------------------------------

using CUE.Net.Devices.Generic;
using CUE.Net.Devices.Mouse.Enums;
using CUE.Net.Native;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local

namespace CUE.Net.Devices.Mouse
{
    /// <summary>
    ///   Represents specific information for a CUE mouse.
    /// </summary>
    public class CorsairMouseDeviceInfo : GenericDeviceInfo
    {
        #region Constructors

        /// <summary>
        ///   Internal constructor of managed <see cref="CorsairMouseDeviceInfo" />.
        /// </summary>
        /// <param name="nativeInfo">The native <see cref="_CorsairDeviceInfo" />-struct</param>
        internal CorsairMouseDeviceInfo(_CorsairDeviceInfo nativeInfo) : base(nativeInfo) => PhysicalLayout =
            (CorsairPhysicalMouseLayout) nativeInfo.physicalLayout;

        #endregion

        #region Properties & Fields

        /// <summary>
        ///   Gets the physical layout of the mouse.
        /// </summary>
        public CorsairPhysicalMouseLayout PhysicalLayout { get; private set; }

        #endregion
    }
}