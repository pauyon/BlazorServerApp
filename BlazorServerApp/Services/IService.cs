using BlazorServerApp.Shared.Domain.Entities.Interfaces;

namespace BlazorServerApp.Services
{
    public interface IService<TEntity> 
        where TEntity : class, IEntityBase, new()
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity?> GetById(int id);

        Task<IEnumerable<TEntity>?> GetByIdTemporal(int id);

        Task<TEntity> Add(TEntity entity);

        Task<bool> Update(TEntity entity);

        Task<bool> Delete(TEntity entity);
    }
}
