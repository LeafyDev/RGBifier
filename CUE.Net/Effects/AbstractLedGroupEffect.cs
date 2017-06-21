﻿// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global

using CUE.Net.Groups;

namespace CUE.Net.Effects
{
    /// <summary>
    /// Represents a basic effect targeting an <see cref="ILedGroup"/>.
    /// </summary>
    public abstract class AbstractLedGroupEffect<T> : IEffect<ILedGroup>
        where T : ILedGroup
    {
        #region Properties & Fields

        /// <summary>
        /// Gets or sets if this effect has finished all of his work.
        /// </summary>
        public bool IsDone { get; protected set; }

        /// <summary>
        /// Gets the <see cref="ILedGroup"/> this effect is targeting.
        /// </summary>
        protected T LedGroup { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the effect.
        /// </summary>
        /// <param name="deltaTime">The elapsed time (in seconds) since the last update.</param>
        public abstract void Update(float deltaTime);

        /// <summary>
        /// Checks if the effect can be applied to the target object.
        /// </summary>
        /// <param name="target">The <see cref="IEffectTarget{T}"/> this effect is attached to.</param>
        /// <returns><c>true</c> if the effect can be attached; otherwise, <c>false</c>.</returns>
        public virtual bool CanBeAppliedTo(ILedGroup target)
        {
            return target is T;
        }

        /// <summary>
        /// Hook which is called when the effect is attached to a device.
        /// </summary>
        /// <param name="target">The <see cref="ILedGroup"/> this effect is attached to.</param>
        public virtual void OnAttach(ILedGroup target)
        {
            LedGroup = (T)target;
        }

        /// <summary>
        /// Hook which is called when the effect is detached from a device.
        /// </summary>
        /// <param name="target">The <see cref="ILedGroup"/> this effect is detached from.</param>
        public virtual void OnDetach(ILedGroup target)
        {
            LedGroup = default(T);
        }

        #endregion
    }

    /// <summary>
    /// Represents a basic effect targeting an <see cref="ILedGroup"/>.
    /// </summary>
    public abstract class AbstractLedGroupEffect : AbstractLedGroupEffect<ILedGroup>
    { }
}
