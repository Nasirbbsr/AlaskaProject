using System;

namespace Alaska.Interface.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Regenerates the context.
        /// </summary>
        void RegenerateContext();

        /// <summary>
        /// Saves Context changes.
        /// </summary>
        void Save();
    }
}
