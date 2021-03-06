﻿// ---------------------------------------------------------
// Copyrights (c) 2014-2017 Seditio 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Collections.Generic;
using System.Drawing;

using CUE.Net.ColorCorrection;
using CUE.Net.Devices.Generic;
using CUE.Net.Devices.Keyboard.Enums;
using CUE.Net.Effects;

namespace CUE.Net.Brushes
{
    /// <summary>
    ///   Represents a basic brush.
    /// </summary>
    public interface IBrush : IEffectTarget<IBrush>
    {
        /// <summary>
        ///   Gets or sets the calculation mode used for the rectangle/points used for color-selection in brushes.
        /// </summary>
        BrushCalculationMode BrushCalculationMode { get; set; }

        /// <summary>
        ///   Gets or sets the overall percentage brightness of the brush.
        /// </summary>
        float Brightness { get; set; }

        /// <summary>
        ///   Gets or sets the overall percentage opacity of the brush.
        /// </summary>
        float Opacity { get; set; }

        /// <summary>
        ///   Gets a list of color-corrections used to correct the colors of the brush.
        /// </summary>
        IList<IColorCorrection> ColorCorrections { get; }

        /// <summary>
        ///   Gets the Rectangle used in the last render pass.
        /// </summary>
        RectangleF RenderedRectangle { get; }

        /// <summary>
        ///   Gets a dictionary containing all colors for points calculated in the last render pass.
        /// </summary>
        Dictionary<BrushRenderTarget, CorsairColor> RenderedTargets { get; }

        /// <summary>
        ///   Performas the render pass of the brush and calculates the raw colors for all requested points.
        /// </summary>
        /// <param name="rectangle">The rectangle in which the brush should be drawn.</param>
        /// <param name="renderTargets">The targets (keys/points) of which the color should be calculated.</param>
        void PerformRender(RectangleF rectangle, IEnumerable<BrushRenderTarget> renderTargets);

        /// <summary>
        ///   Performs the finalize pass of the brush and calculates the final colors for all previously calculated points.
        /// </summary>
        void PerformFinalize();
    }
}