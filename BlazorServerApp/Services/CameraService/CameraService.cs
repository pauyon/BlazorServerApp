using BlazorServerApp.Configurations;
using BlazorServerApp.Shared.Domain.Entities;

namespace BlazorServerApp.Services.CameraService
{
    public class CameraService : Service<Camera>, ICameraService
    {
        public CameraService(HttpClient httpClient) : base(httpClient, SiteConstants.ApiEndpoints.Camera)
        {
        }
    }
}
