﻿// ---------------------------------------------------------
// Copyrights (c) 2014-2017 Seditio 🍂 All rights reserved.
// ---------------------------------------------------------

using CUE.Net.Devices.Generic;

namespace CUE.Net.Gradients
{
    /// <summary>
    ///   Represents a basic gradient.
    /// </summary>
    public interface IGradient
    {
        /// <summary>
        ///   Gets the color of the gradient on the specified offset.
        /// </summary>
        /// <param name="offset">The percentage offset to take the color from.</param>
        /// <returns>The color at the specific offset.</returns>
        CorsairColor GetColor(float offset);
    }
}