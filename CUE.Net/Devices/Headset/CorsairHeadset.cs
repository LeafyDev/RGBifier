﻿// ---------------------------------------------------------
// Copyrights (c) 2014-2017 Seditio 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Drawing;

using CUE.Net.Devices.Generic;
using CUE.Net.Devices.Headset.Enums;

namespace CUE.Net.Devices.Headset
{
    /// <summary>
    ///   Represents the SDK for a corsair headset.
    /// </summary>
    public class CorsairHeadset : AbstractCueDevice
    {
        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="CorsairHeadset" /> class.
        /// </summary>
        /// <param name="info">The specific information provided by CUE for the headset</param>
        internal CorsairHeadset(CorsairHeadsetDeviceInfo info) : base(info) => HeadsetDeviceInfo = info;

        #endregion

        #region Properties & Fields

        /// <summary>
        ///   Gets specific information provided by CUE for the headset.
        /// </summary>
        public CorsairHeadsetDeviceInfo HeadsetDeviceInfo { get; }

        #endregion

        #region Methods

        /// <summary>
        ///   Initializes the the headset.
        /// </summary>
        public override void Initialize()
        {
            InitializeLed(CorsairHeadsetLedId.LeftLogo, new RectangleF(0, 0, 1, 1));
            InitializeLed(CorsairHeadsetLedId.RightLogo, new RectangleF(1, 0, 1, 1));

            base.Initialize();
        }

        #endregion
    }
}