// ---------------------------------------------------------
// Copyrights (c) 2014-2017 Seditio 🍂 All rights reserved.
// ---------------------------------------------------------

using CUE.Net.Devices.Generic;
using CUE.Net.Devices.Generic.Enums;

// ReSharper disable UnusedMethodReturnValue.Global

namespace CUE.Net.Groups.Extensions
{
    /// <summary>
    ///   Offers some extensions and helper-methods for ledgroup related things.
    /// </summary>
    public static class LedGroupExtension
    {
        /// <summary>
        ///   Converts the given <see cref="AbstractLedGroup" /> to a <see cref="ListLedGroup" />.
        /// </summary>
        /// <param name="ledGroup">The <see cref="AbstractLedGroup" /> to convert.</param>
        /// <returns>The converted <see cref="ListLedGroup" />.</returns>
        public static ListLedGroup ToListLedGroup(this AbstractLedGroup ledGroup)
        {
            var listLedGroup = ledGroup as ListLedGroup;
            // ReSharper disable once InvertIf
            if(listLedGroup == null)
            {
                var wasAttached = ledGroup.Detach();
                listLedGroup = new ListLedGroup(ledGroup.Device, wasAttached, ledGroup.GetLeds()) {Brush = ledGroup.Brush};
            }
            return listLedGroup;
        }

        /// <summary>
        ///   Returns a new <see cref="ListLedGroup" /> which contains all LEDs from the given ledgroup excluding the specified
        ///   ones.
        /// </summary>
        /// <param name="ledGroup">The base ledgroup.</param>
        /// <param name="ledIds">The ids of the LEDs to exclude.</param>
        /// <returns>The new <see cref="ListLedGroup" />.</returns>
        public static ListLedGroup Exclude(this AbstractLedGroup ledGroup, params CorsairLedId[] ledIds)
        {
            var listLedGroup = ledGroup.ToListLedGroup();
            foreach(var ledId in ledIds)
                listLedGroup.RemoveLed(ledId);
            return listLedGroup;
        }

        /// <summary>
        ///   Returns a new <see cref="ListLedGroup" /> which contains all LEDs from the given ledgroup excluding the specified
        ///   ones.
        /// </summary>
        /// <param name="ledGroup">The base ledgroup.</param>
        /// <param name="ledIds">The LEDs to exclude.</param>
        /// <returns>The new <see cref="ListLedGroup" />.</returns>
        public static ListLedGroup Exclude(this AbstractLedGroup ledGroup, params CorsairLed[] ledIds)
        {
            var listLedGroup = ledGroup.ToListLedGroup();
            foreach(var led in ledIds)
                listLedGroup.RemoveLed(led);
            return listLedGroup;
        }

        // ReSharper disable once UnusedMethodReturnValue.Global
        /// <summary>
        ///   Attaches the given ledgroup to the device.
        /// </summary>
        /// <param name="ledGroup">The ledgroup to attach.</param>
        /// <returns><c>true</c> if the ledgroup could be attached; otherwise, <c>false</c>.</returns>
        public static bool Attach(this AbstractLedGroup ledGroup) => ledGroup.Device?.AttachLedGroup(ledGroup) ?? false;

        /// <summary>
        ///   Detaches the given ledgroup from the device.
        /// </summary>
        /// <param name="ledGroup">The ledgroup to attach.</param>
        /// <returns><c>true</c> if the ledgroup could be detached; otherwise, <c>false</c>.</returns>
        public static bool Detach(this AbstractLedGroup ledGroup) => ledGroup.Device?.DetachLedGroup(ledGroup) ?? false;
    }
}