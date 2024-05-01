namespace BlazorServerApp.Shared.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICameraRepository CameraRepository { get; }
        IAccessoryRepository AccessoryRepository { get; }
        int Save();
    }
}
