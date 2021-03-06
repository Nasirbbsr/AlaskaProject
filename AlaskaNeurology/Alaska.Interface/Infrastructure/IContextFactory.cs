﻿using System.Data.Entity;

namespace Alaska.Interface.Infrastructure
{
    public interface IContextFactory<out TContext>
          where TContext : DbContext
    {
        /// <summary>
        /// Creates new database context
        /// </summary>
        /// <returns>New Database context</returns>
        TContext Create();
    }
}
