// ---------------------------------------------------------
// Copyrights (c) 2014-2017 Seditio 🍂 All rights reserved.
// ---------------------------------------------------------

using System;
using System.Drawing;
using System.Runtime.InteropServices;

using CUE.Net.Devices.Generic;
using CUE.Net.Native;

namespace CUE.Net.Devices.Keyboard
{
    /// <summary>
    ///   Represents the SDK for a corsair keyboard.
    /// </summary>
    public class CorsairKeyboard : AbstractCueDevice
    {
        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="CorsairKeyboard" /> class.
        /// </summary>
        /// <param name="info">The specific information provided by CUE for the keyboard</param>
        internal CorsairKeyboard(CorsairKeyboardDeviceInfo info) : base(info) => KeyboardDeviceInfo = info;

        #endregion

        #region Methods

        /// <summary>
        ///   Initializes the keyboard.
        /// </summary>
        public override void Initialize()
        {
            var nativeLedPositions = Marshal.PtrToStructure<_CorsairLedPositions>(_CUESDK.CorsairGetLedPositions());
            var structSize = Marshal.SizeOf<_CorsairLedPosition>();
            var ptr = nativeLedPositions.pLedPosition;
            for(var i = 0; i < nativeLedPositions.numberOfLed; i++)
            {
                var ledPosition = Marshal.PtrToStructure<_CorsairLedPosition>(ptr);
                InitializeLed(ledPosition.ledId,
                    new RectangleF((float) ledPosition.left, (float) ledPosition.top, (float) ledPosition.width, (float) ledPosition.height));

                ptr = new IntPtr(ptr.ToInt64() + structSize);
            }

            base.Initialize();
        }

        #endregion

        #region Properties & Fields

        /// <summary>
        ///   Gets specific information provided by CUE for the keyboard.
        /// </summary>
        public CorsairKeyboardDeviceInfo KeyboardDeviceInfo { get; }

        #region Indexers

        /// <summary>
        ///   Gets the <see cref="CorsairLed" /> representing the given character by calling the SDK-method
        ///   'CorsairGetLedIdForKeyName'.<br />
        ///   Note that this currently only works for letters.
        /// </summary>
        /// <param name="key">The character of the key.</param>
        /// <returns>The led representing the given character or null if no led is found.</returns>
        public CorsairLed this[char key]
        {
            get
            {
                var ledId = _CUESDK.CorsairGetLedIdForKeyName(key);
                return LedMapping.TryGetValue(ledId, out CorsairLed led) ? led : null;
            }
        }

        #endregion

        #endregion
    }
}