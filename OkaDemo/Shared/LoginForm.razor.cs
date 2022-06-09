using Microsoft.AspNetCore.Components;
namespace OkaDemo.Shared;
public partial class LoginForm
{
    [Inject]
    public NavigationManager Navigation { get; set; }
    [Parameter]
    public string ReturnUrl { get; set; }

    protected override async Task OnInitializedAsync()
    {
        ReturnUrl = Navigation.ToBaseRelativePath(Navigation.Uri);
    }
}
