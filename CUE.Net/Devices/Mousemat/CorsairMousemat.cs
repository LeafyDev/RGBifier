// ---------------------------------------------------------
// Copyrights (c) 2014-2017 Seditio 🍂 All rights reserved.
// ---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

using CUE.Net.Devices.Generic;
using CUE.Net.Devices.Generic.Enums;
using CUE.Net.Exceptions;
using CUE.Net.Native;

namespace CUE.Net.Devices.Mousemat
{
    /// <summary>
    ///   Represents the SDK for a corsair mousemat.
    /// </summary>
    public class CorsairMousemat : AbstractCueDevice
    {
        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="CorsairMousemat" /> class.
        /// </summary>
        /// <param name="info">The specific information provided by CUE for the mousemat</param>
        internal CorsairMousemat(CorsairMousematDeviceInfo info) : base(info) => MousematDeviceInfo = info;

        #endregion

        #region Properties & Fields

        /// <summary>
        ///   Gets specific information provided by CUE for the mousemat.
        /// </summary>
        public CorsairMousematDeviceInfo MousematDeviceInfo { get; }

        #endregion

        #region Methods

        /// <summary>
        ///   Initializes the mousemat.
        /// </summary>
        public override void Initialize()
        {
            var deviceCount = _CUESDK.CorsairGetDeviceCount();

            // Get mousemat device index
            var mousematIndex = -1;
            for(var i = 0; i < deviceCount; i++)
            {
                var nativeDeviceInfo = Marshal.PtrToStructure<_CorsairDeviceInfo>(_CUESDK.CorsairGetDeviceInfo(i));
                var info = new GenericDeviceInfo(nativeDeviceInfo);
                if(info.Type != CorsairDeviceType.Mousemat)
                    continue;

                mousematIndex = i;
                break;
            }
            if(mousematIndex < 0)
                throw new WrapperException("Can't determine mousemat device index");

            var nativeLedPositions = Marshal.PtrToStructure<_CorsairLedPositions>(_CUESDK.CorsairGetLedPositionsByDeviceIndex(mousematIndex));
            var structSize = Marshal.SizeOf<_CorsairLedPosition>();
            var ptr = nativeLedPositions.pLedPosition;

            // Put the positions in an array for sorting later on
            var positions = new List<_CorsairLedPosition>();
            for(var i = 0; i < nativeLedPositions.numberOfLed; i++)
            {
                var ledPosition = Marshal.PtrToStructure<_CorsairLedPosition>(ptr);
                ptr = new IntPtr(ptr.ToInt64() + structSize);
                positions.Add(ledPosition);
            }

            // Sort for easy iteration by clients
            foreach(var ledPosition in positions.OrderBy(p => p.ledId))
                InitializeLed(ledPosition.ledId,
                    new RectangleF((float) ledPosition.left, (float) ledPosition.top, (float) ledPosition.width, (float) ledPosition.height));

            base.Initialize();
        }

        #endregion
    }
}