using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorServerApp.Client.Pages.Shared;

public class PageBase : ComponentBase
{
    public virtual PageDetails? PageDetails { get; set; } = new();

    public virtual bool IsLoading { get; set; } = true;

    [Inject]
    protected NavigationManager? NavigationManager { get; set; }
    
    [Inject]
    protected IDialogService? DialogService { get; set; }

    [Inject]
    protected ISnackbar? Snackbar { get; set; }
}
