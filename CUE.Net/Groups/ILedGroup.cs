// ---------------------------------------------------------
// Copyrights (c) 2014-2017 Seditio 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Collections.Generic;

using CUE.Net.Brushes;
using CUE.Net.Devices.Generic;
using CUE.Net.Effects;

namespace CUE.Net.Groups
{
    /// <summary>
    ///   Represents a basic led-group.
    /// </summary>
    public interface ILedGroup : IEffectTarget<ILedGroup>
    {
        /// <summary>
        ///   Gets or sets the brush which should be drawn over this group.
        /// </summary>
        IBrush Brush { get; set; }

        /// <summary>
        ///   Gets or sets the z-index of this ledgroup to allow ordering them before drawing. (lowest first) (default: 0)
        /// </summary>
        int ZIndex { get; set; }

        /// <summary>
        ///   Gets a list containing all LEDs of this group.
        /// </summary>
        /// <returns>The list containing all LEDs of this group.</returns>
        IEnumerable<CorsairLed> GetLeds();
    }
}