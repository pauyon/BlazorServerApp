using BlazorServerApp.Shared.Domain.Entities;
using BlazorServerApp.Shared.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerApp.Api.Infrastructure.Repositories
{
    public class AccessoryRepository : EntityRepository<Accessory>, IAccessoryRepository
    {
        private readonly SqlServerDbContext _dbContext;

        public AccessoryRepository(SqlServerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IEnumerable<Accessory>?> GetTemporal(int id)
        {
            return await _dbContext.Set<Accessory>()
                .TemporalAll()
                .OrderBy(c => EF.Property<DateTime>(c, "PeriodStart"))
                .Where(x => x.Id == id)
                .Select(x =>
                    new Accessory
                    {
                        Id = x.Id,
                        Make = x.Make,
                        Model = x.Model,
                        DisplayPeriodStart = EF.Property<DateTime>(x, "PeriodStart"),
                        DisplayPeriodEnd = EF.Property<DateTime>(x, "PeriodEnd"),
                    }
                ).ToListAsync();
        }
    }
}
