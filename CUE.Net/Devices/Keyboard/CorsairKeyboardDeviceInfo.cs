// ---------------------------------------------------------
// Copyrights (c) 2014-2017 Seditio 🍂 All rights reserved.
// ---------------------------------------------------------

using CUE.Net.Devices.Generic;
using CUE.Net.Devices.Keyboard.Enums;
using CUE.Net.Native;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local

namespace CUE.Net.Devices.Keyboard
{
    /// <summary>
    ///   Represents specific information for a CUE keyboard.
    /// </summary>
    public class CorsairKeyboardDeviceInfo : GenericDeviceInfo
    {
        #region Constructors

        /// <summary>
        ///   Internal constructor of managed CorsairDeviceInfo.
        /// </summary>
        /// <param name="nativeInfo">The native CorsairDeviceInfo-struct</param>
        internal CorsairKeyboardDeviceInfo(_CorsairDeviceInfo nativeInfo) : base(nativeInfo)
        {
            PhysicalLayout = (CorsairPhysicalKeyboardLayout) nativeInfo.physicalLayout;
            LogicalLayout = (CorsairLogicalKeyboardLayout) nativeInfo.logicalLayout;
        }

        #endregion

        #region Properties & Fields

        /// <summary>
        ///   Gets the physical layout of the keyboard.
        /// </summary>
        public CorsairPhysicalKeyboardLayout PhysicalLayout { get; private set; }

        /// <summary>
        ///   Gets the logical layout of the keyboard as set in CUE settings.
        /// </summary>
        public CorsairLogicalKeyboardLayout LogicalLayout { get; private set; }

        #endregion
    }
}