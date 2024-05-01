using BlazorServerApp.Shared.Domain.Repositories;

namespace BlazorServerApp.Server.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICameraRepository CameraRepository { get; }
        IAccessoryRepository AccessoryRepository { get; }
        int Save();
    }
}
