using BlazorServerApp.Client.Configurations;
using BlazorServerApp.Shared.Domain.Entities;

namespace BlazorServerApp.Client.Services.CameraService;

public class CameraService : Service<Camera>, ICameraService
{
    public CameraService(HttpClient httpClient) : base(httpClient, SiteConstants.ApiEndpoints.Camera)
    {
    }
}
