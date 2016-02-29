using Alaska.Interface.Infrastructure;
using System.Data.Entity;

namespace Alaska.DB.Infrastructure
{
    public sealed partial class AlaskaUnitOfWork
     : GenericUnitOfWork<DbContext>, IAlaskaUnitOfWork
    {
        public AlaskaUnitOfWork(IContextFactory<DbContext> contextFactory)
            : base(contextFactory)
        {

        }
        public AlaskaUnitOfWork(DbContext context)
           : base(context)
        {

        }

    }
}
