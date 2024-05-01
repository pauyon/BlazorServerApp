namespace BlazorServerApp.Api.Infrastructure.Repositories
{
    public class EntityTemporalRepository<THistory>
        where THistory : class
    {
        public virtual Task<IEnumerable<THistory>> GetByIdTemporal(int id)
        {
            throw new NotImplementedException();
        }
    }
}
