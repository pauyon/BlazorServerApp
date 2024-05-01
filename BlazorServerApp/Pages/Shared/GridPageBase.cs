using BlazorServerApp.Services;
using BlazorServerApp.Shared.Domain.Entities.Interfaces;
using Humanizer;
using Microsoft.AspNetCore.Components;

namespace BlazorServerApp.Pages.Shared
{
    public class GridPageBase<TEntity> : PageBase
        where TEntity : class, IEntityBase, new()
    {
        public string SearchFilter { get; set; } = string.Empty;

        protected List<TEntity>? Entities { get; set; }

        [Inject]
        protected IService<TEntity>? EntityService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            PageDetails!.TabTitle = typeof(TEntity).Name.Pluralize();
            PageDetails!.PageTitle = typeof(TEntity).Name.Pluralize();
            Entities = await EntityService!.GetAll();

            IsLoading = Entities != null ? false : true;
        }

        protected virtual void AddEditRecord(TEntity? entity)
        {
            if (entity == null)
            {
                NavigationManager!.NavigateTo($"/{typeof(TEntity).Name.ToLower()}/0");
            }
            else
            {
                NavigationManager!.NavigateTo($"/{typeof(TEntity).Name.ToLower()}/{entity.Id}");
            }

        }

        protected virtual async Task DeleteRecord(TEntity entity)
        {
        }

        protected bool RowContainsSearchString(IEnumerable<object?> properties)
        {
            if (string.IsNullOrWhiteSpace(SearchFilter))
            {
                return true;
            }

            if (properties == null)
            {
                return true;
            }

            foreach (var property in properties)
            {
                if (property == null)
                {
                    continue;
                }

                var stringValue = property.ToString() ?? string.Empty;

                // Check the rest of the values with a contains
                if (stringValue.Contains(SearchFilter, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
