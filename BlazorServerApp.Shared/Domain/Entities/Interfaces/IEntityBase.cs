using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServerApp.Shared.Domain.Entities.Interfaces
{
    public interface IEntityBase
    {
        public int Id { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public DateTime DisplayPeriodEnd { get; set; }
        public DateTime DisplayPeriodStart { get; set; }
    }
}
