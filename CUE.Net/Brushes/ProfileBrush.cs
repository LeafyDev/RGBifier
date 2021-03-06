﻿// ---------------------------------------------------------
// Copyrights (c) 2014-2017 Seditio 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Collections.Generic;
using System.Drawing;

using CUE.Net.Devices.Generic;
using CUE.Net.Devices.Generic.Enums;

// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace CUE.Net.Brushes
{
    /// <summary>
    ///   Represents a brush drawing the lighting of a CUE profile.
    /// </summary>
    public class ProfileBrush : AbstractBrush
    {
        #region Properties & Fields

        private Dictionary<CorsairLedId, CorsairColor> _colors;

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="ProfileBrush" /> class.
        /// </summary>
        /// <param name="keyLights">The light settings of the CUE profile.</param>
        internal ProfileBrush(Dictionary<CorsairLedId, CorsairColor> keyLights) => _colors = keyLights;

        #endregion

        #region Methods

        /// <summary>
        ///   Gets the color at an specific point assuming the brush is drawn into the given rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle in which the brush should be drawn.</param>
        /// <param name="renderTarget">The target (key/point) from which the color should be taken.</param>
        /// <returns>The color at the specified point.</returns>
        protected override CorsairColor GetColorAtPoint(RectangleF rectangle, BrushRenderTarget renderTarget)
        {
            var led = CueSDK.KeyboardSDK[renderTarget.LedId];
            if(led == null)
                return CorsairColor.Transparent;

            CorsairColor color;
            return !_colors.TryGetValue(led.Id, out color) ? CorsairColor.Transparent : color;
        }

        #endregion
    }
}