using Alaska.Interface.Infrastructure;
using System.Data.Entity;

namespace Alaska.DB.Infrastructure
{
    public sealed class AlaskaContextFactory
        : IContextFactory<DbContext>
    {
        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlaskaContextFactory"/> class.
        /// </summary>
        /// <param name="connectionStringOrName">Name of the connection string or actual connection string.</param>
        public AlaskaContextFactory(string connectionStringOrName)
        {
            _connectionString = connectionStringOrName;
        }

        /// <summary>
        /// Creates new database context.
        /// </summary>
        /// <returns>DbContext: <see cref="AlaskaContext"/></returns>
        public DbContext Create()
        {
            return new AlaskaContext(_connectionString);
        }
    }
}
