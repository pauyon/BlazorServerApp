using BlazorServerApp.Shared.Domain.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServerApp.Shared.Domain.Entities
{
    public class EntityBase : IEntityBase
    {
        [Required]
        public int Id { get; set; }

        public string? Make { get; set; }

        public string? Model { get; set; }

        [NotMapped]
        public DateTime DisplayPeriodEnd { get; set; }

        [NotMapped]
        public DateTime DisplayPeriodStart { get; set; }
    }
}
