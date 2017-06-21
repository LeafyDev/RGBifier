﻿// ReSharper disable MemberCanBePrivate.Global

using CUE.Net.Brushes;

namespace CUE.Net.Effects
{
    /// <summary>
    /// Represents a basic effect targeting an <see cref="IBrush"/>.
    /// </summary>
    public abstract class AbstractBrushEffect<T> : IEffect<IBrush>
        where T : IBrush
    {
        #region Properties & Fields

        /// <summary>
        /// Gets or sets if this effect has finished all of his work.
        /// </summary>
        public bool IsDone { get; protected set; }

        /// <summary>
        /// Gets the <see cref="IBrush"/> this effect is targeting.
        /// </summary>
        protected T Brush { get; set; }

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
        public virtual bool CanBeAppliedTo(IBrush target) => target is T;

        /// <summary>
        /// Hook which is called when the effect is attached to a device.
        /// </summary>
        /// <param name="target">The <see cref="IBrush"/> this effect is attached to.</param>
        public virtual void OnAttach(IBrush target)
        {
            Brush = (T)target;
        }

        /// <summary>
        /// Hook which is called when the effect is detached from a device.
        /// </summary>
        /// <param name="target">The <see cref="IBrush"/> this effect is detached from.</param>
        public virtual void OnDetach(IBrush target)
        {
            Brush = default(T);
        }

        #endregion
    }

    /// <summary>
    /// Represents a basic effect targeting an <see cref="IBrush"/>.
    /// </summary>
    public abstract class AbstractBrushEffect : AbstractBrushEffect<IBrush>
    { }
}
