﻿// ---------------------------------------------------------
// Copyrights (c) 2014-2017 Seditio 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Drawing;

using CUE.Net.Devices.Generic;
using CUE.Net.Devices.Mouse.Enums;
using CUE.Net.Exceptions;

namespace CUE.Net.Devices.Mouse
{
    /// <summary>
    ///   Represents the SDK for a corsair mouse.
    /// </summary>
    public class CorsairMouse : AbstractCueDevice
    {
        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="CorsairMouse" /> class.
        /// </summary>
        /// <param name="info">The specific information provided by CUE for the mouse</param>
        internal CorsairMouse(CorsairMouseDeviceInfo info) : base(info) => MouseDeviceInfo = info;

        #endregion

        #region Properties & Fields

        /// <summary>
        ///   Gets specific information provided by CUE for the mouse.
        /// </summary>
        public CorsairMouseDeviceInfo MouseDeviceInfo { get; }

        #endregion

        #region Methods

        /// <summary>
        ///   Initializes the mouse.
        /// </summary>
        public override void Initialize()
        {
            switch(MouseDeviceInfo.PhysicalLayout)
            {
                case CorsairPhysicalMouseLayout.Zones1:
                    InitializeLed(CorsairMouseLedId.B1, new RectangleF(0, 0, 1, 1));
                    break;
                case CorsairPhysicalMouseLayout.Zones2:
                    InitializeLed(CorsairMouseLedId.B1, new RectangleF(0, 0, 1, 1));
                    InitializeLed(CorsairMouseLedId.B2, new RectangleF(1, 0, 1, 1));
                    break;
                case CorsairPhysicalMouseLayout.Zones3:
                    InitializeLed(CorsairMouseLedId.B1, new RectangleF(0, 0, 1, 1));
                    InitializeLed(CorsairMouseLedId.B2, new RectangleF(1, 0, 1, 1));
                    InitializeLed(CorsairMouseLedId.B3, new RectangleF(2, 0, 1, 1));
                    break;
                case CorsairPhysicalMouseLayout.Zones4:
                    InitializeLed(CorsairMouseLedId.B1, new RectangleF(0, 0, 1, 1));
                    InitializeLed(CorsairMouseLedId.B2, new RectangleF(1, 0, 1, 1));
                    InitializeLed(CorsairMouseLedId.B3, new RectangleF(2, 0, 1, 1));
                    InitializeLed(CorsairMouseLedId.B4, new RectangleF(3, 0, 1, 1));
                    break;
                default: throw new WrapperException($"Can't initial mouse with layout '{MouseDeviceInfo.PhysicalLayout}'");
            }

            base.Initialize();
        }

        #endregion
    }
}