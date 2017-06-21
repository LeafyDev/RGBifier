// ---------------------------------------------------------
// Copyrights (c) 2014-2017 Seditio 🍂 All rights reserved.
// ---------------------------------------------------------

using System.Collections.Generic;

using CUE.Net.Brushes;
using CUE.Net.Devices;
using CUE.Net.Devices.Generic;
using CUE.Net.Effects;
using CUE.Net.Groups.Extensions;

namespace CUE.Net.Groups
{
    /// <summary>
    ///   Represents a basic ledgroup.
    /// </summary>
    public abstract class AbstractLedGroup : AbstractEffectTarget<ILedGroup>, ILedGroup
    {
        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="AbstractLedGroup" /> class.
        /// </summary>
        /// <param name="device">The device this ledgroup belongs to.</param>
        /// <param name="autoAttach">Specifies whether this group should be automatically attached or not.</param>
        protected AbstractLedGroup(ICueDevice device, bool autoAttach = true)
        {
            Device = device;

            if(autoAttach)
                this.Attach();
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Gets a list containing all LEDs of this group.
        /// </summary>
        /// <returns>The list containing all LEDs of this group.</returns>
        public abstract IEnumerable<CorsairLed> GetLeds();

        #endregion

        #region Properties & Fields

        /// <summary>
        ///   Gets the strongly-typed target used for the effect.
        /// </summary>
        protected override ILedGroup EffectTarget => this;

        /// <summary>
        ///   Gets the device this ledgroup belongs to.
        /// </summary>
        public ICueDevice Device { get; }

        /// <summary>
        ///   Gets or sets the brush which should be drawn over this group.
        /// </summary>
        public IBrush Brush { get; set; }

        /// <summary>
        ///   Gets or sets the z-index of this ledgroup to allow ordering them before drawing. (lowest first) (default: 0)
        /// </summary>
        public int ZIndex { get; set; } = 0;

        #endregion
    }
}