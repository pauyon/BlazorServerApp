using BlazorServerApp.Shared.Domain.Repositories;

namespace BlazorServerApp.Api.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerDbContext _dbContext;

        public UnitOfWork(SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
            CameraRepository = new CameraRepository(dbContext);
            AccessoryRepository = new AccessoryRepository(dbContext);
        }

        public ICameraRepository CameraRepository { get; private set; }
        public IAccessoryRepository AccessoryRepository { get; private set; }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
    }
}
