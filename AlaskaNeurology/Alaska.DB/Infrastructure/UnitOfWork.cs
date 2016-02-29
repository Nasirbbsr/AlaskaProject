using System;
using Alaska.DB.Repository;
using Alaska.Model.DataModel;

namespace Alaska.DB.Infrastructure
    {
    public class UnitOfWork : IDisposable
    {
        private AlaskaContext context;
        private int _screenId;
        private Repository<People> peopleRepository;
        private ScreenRepository screenRepository;
        private string _connString;
        public UnitOfWork(string ConnectionString= @"Data Source = (local); Initial Catalog = AKNC; Integrated Security = SSPI;",int screenId=1)
        {
            _screenId = screenId;
            context =   new AlaskaContext(ConnectionString);
            _connString = ConnectionString;
        }
        public Repository<People> PeopleRepository
        {
            get
            {

                if (this.peopleRepository == null)
                {
                    this.peopleRepository = new Repository<People>(context);
                }
                return peopleRepository;
            }
        }
        public ScreenRepository ScreenRepo
        {
            get
            {

                if (screenRepository == null)
                {
                    screenRepository = new ScreenRepository(_screenId, context);
                }
                return screenRepository;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
     

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
