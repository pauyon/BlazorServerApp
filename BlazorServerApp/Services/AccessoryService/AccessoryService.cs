using BlazorServerApp.Configurations;
using BlazorServerApp.Shared.Domain.Entities;

namespace BlazorServerApp.Services.AccessoryService
{
    public class AccessoryService : Service<Accessory>, IAccessoryService
    {
        public AccessoryService(HttpClient httpClient) : base(httpClient, SiteConstants.ApiEndpoints.Accessory)
        {
        }
    }
}
