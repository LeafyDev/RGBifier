﻿namespace CUE.Net.Devices.Keyboard.Enums
{
    /// <summary>
    /// Contains a list of all brush calculation modes.
    /// </summary>
    public enum BrushCalculationMode
    {
        /// <summary>
        /// The calculation rectangle for brushes will be the rectangle around the ledgroup the brush is applied to.
        /// </summary>
        Relative,
        /// <summary>
        /// The calculation rectangle for brushes will always be the whole keyboard.
        /// </summary>
        Absolute
    }
}
