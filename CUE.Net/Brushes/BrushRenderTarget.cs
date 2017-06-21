// ---------------------------------------------------------
// Copyrights (c) 2014-2017 Seditio 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Drawing;

using CUE.Net.Devices.Generic.Enums;
using CUE.Net.Helper;

namespace CUE.Net.Brushes
{
    /// <summary>
    ///   Represents a single target of a brush render.
    /// </summary>
    public class BrushRenderTarget
    {
        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="BrushRenderTarget" /> class.
        /// </summary>
        /// <param name="ledId">The ID of the target-LED.</param>
        /// <param name="rectangle">The rectangle representing the area to render the target-LED.</param>
        public BrushRenderTarget(CorsairLedId ledId, RectangleF rectangle)
        {
            Rectangle = rectangle;
            LedId = ledId;

            Point = rectangle.GetCenter();
        }

        #endregion

        #region Properties & Fields

        /// <summary>
        ///   Gets the ID of the target-LED.
        /// </summary>
        public CorsairLedId LedId { get; }

        /// <summary>
        ///   Gets the rectangle representing the area to render the target-LED.
        /// </summary>
        public RectangleF Rectangle { get; }

        /// <summary>
        ///   Gets the point representing the position to render the target-LED.
        /// </summary>
        public PointF Point { get; }

        #endregion
    }
}