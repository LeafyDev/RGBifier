using System;
using System.Drawing;
using CUE.Net.Brushes;
using CUE.Net.Devices.Generic;
// ReSharper disable UnusedMember.Global
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable UnusedMember.Local

namespace CUE.Net.Effects
{
    public class RippleEffect : AbstractBrushEffect
    {
        #region Properties & Fields

        private RippleBrush _brush = new RippleBrush();
        public IBrush EffectBrush => _brush;

        #endregion

        #region Constructors

        #endregion

        #region Methods

        public override void Update(float deltaTime)
        {
            throw new NotImplementedException();
        }

        #endregion

        private class RippleBrush : AbstractBrush
        {
            public Color GetColorAtPoint(RectangleF rectangle, PointF point) => FinalizeColor(Color.Black);

            protected override CorsairColor GetColorAtPoint(RectangleF rectangle, BrushRenderTarget renderTarget) => throw new NotImplementedException();
        }
    }
}
