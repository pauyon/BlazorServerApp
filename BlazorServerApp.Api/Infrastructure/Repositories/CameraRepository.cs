using BlazorServerApp.Shared.Domain.Repositories;
using BlazorServerApp.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerApp.Api.Infrastructure.Repositories
{
    public class CameraRepository : EntityRepository<Camera>, ICameraRepository
    {
        private readonly SqlServerDbContext _dbContext;

        public CameraRepository(SqlServerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IEnumerable<Camera>?> GetTemporal(int id)
        {
            return await _dbContext.Set<Camera>()
                .TemporalAll()
                .OrderBy(c => EF.Property<DateTime>(c, "PeriodStart"))
                .Where(x => x.Id == id)
                .Select(x =>
                    new Camera
                    {
                        Id = x.Id,
                        Make = x.Make,
                        Model = x.Model,
                        Serial = x.Serial,
                        DisplayPeriodStart = EF.Property<DateTime>(x, "PeriodStart"),
                        DisplayPeriodEnd = EF.Property<DateTime>(x, "PeriodEnd"),
                    }
                ).ToListAsync();
        }
    }
}
