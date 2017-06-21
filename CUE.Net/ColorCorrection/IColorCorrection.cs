﻿using CUE.Net.Devices.Generic;

namespace CUE.Net.ColorCorrection
{
    /// <summary>
    /// Represents generic color-correction.
    /// </summary>
    public interface IColorCorrection
    {
        /// <summary>
        /// Applies the color-correction to the given color. 
        /// </summary>
        /// <param name="color">The color to correct.</param>
        void ApplyTo(CorsairColor color);
    }
}
