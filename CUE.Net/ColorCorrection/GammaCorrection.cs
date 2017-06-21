// ---------------------------------------------------------
// Copyrights (c) 2014-2017 Seditio 🍂 All rights reserved.
// ---------------------------------------------------------

using System;

using CUE.Net.Devices.Generic;
using CUE.Net.Helper;

namespace CUE.Net.ColorCorrection
{
    /// <summary>
    ///   Represents a gamma-color-correction.
    /// </summary>
    public class GammaCorrection : IColorCorrection
    {
        #region Methods

        /// <summary>
        ///   Applies the gamma-correction to the given color.
        /// </summary>
        /// <param name="color">The color to correct.</param>
        public void ApplyTo(CorsairColor color)
        {
            if(Math.Abs(R - 1f) > float.Epsilon)
                color.R = ColorHelper.GetIntColorFromFloat((float) Math.Pow(color.GetFloatR(), 1.0 / R));

            if(Math.Abs(G - 1f) > float.Epsilon)
                color.G = ColorHelper.GetIntColorFromFloat((float) Math.Pow(color.GetFloatG(), 1.0 / G));

            if(Math.Abs(B - 1f) > float.Epsilon)
                color.B = ColorHelper.GetIntColorFromFloat((float) Math.Pow(color.GetFloatB(), 1.0 / B));
        }

        #endregion

        #region Operators

        /// <summary>
        ///   Converts a <see cref="float" /> to a <see cref="GammaCorrection" /> using the same value for all colors.
        /// </summary>
        /// <param name="gamma">The float-value to convert.</param>
        public static implicit operator GammaCorrection(float gamma) => new GammaCorrection(gamma);

        #endregion

        #region Properties & Fields

        /// <summary>
        ///   Gets or sets the gamma-value of the color 'red' used for color-correction.
        ///   Values greater than one will make colors brighter, values less than one will make colors darker.
        /// </summary>
        public float R { get; set; }

        /// <summary>
        ///   Gets or sets the gamma-value of the color 'green' used for color-correction.
        ///   Values greater than one will make colors brighter, values less than one will make colors darker.
        /// </summary>
        public float G { get; set; }

        /// <summary>
        ///   Gets or sets the gamma-value of the color 'blue' used for color-correction.
        ///   Values greater than one will make colors brighter, values less than one will make colors darker.
        /// </summary>
        public float B { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="GammaCorrection" /> class using the default-value 1f (no correction) for
        ///   all colors.
        /// </summary>
        public GammaCorrection() : this(1f) { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="GammaCorrection" /> class.
        /// </summary>
        /// <param name="gamma">
        ///   The gamma-value for all colors used for color-correction.
        ///   Values greater than one will make colors brighter, values less than one will make colors darker.
        /// </param>
        public GammaCorrection(float gamma)
        {
            R = gamma;
            G = gamma;
            B = gamma;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="GammaCorrection" /> class.
        /// </summary>
        /// <param name="r">
        ///   The gamma-value for the color 'red' used for color-correction.
        ///   Values greater than one will make colors brighter, values less than one will make colors darker.
        /// </param>
        /// <param name="g">
        ///   The gamma-value for the color 'green' used for color-correction. Values
        ///   greater than one will make colors brighter, values less than one will make colors darker.
        /// </param>
        /// <param name="b">
        ///   The gamma-value for the color 'blue' used for color-correction. Values
        ///   greater than one will make colors brighter, values less than one will make colors darker.
        /// </param>
        public GammaCorrection(float r, float g, float b)
        {
            R = r;
            G = g;
            B = b;
        }

        #endregion
    }
}