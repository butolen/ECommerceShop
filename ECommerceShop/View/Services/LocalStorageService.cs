using Microsoft.JSInterop;

public class LocalStorageService
{
    private readonly IJSRuntime _js;

    public LocalStorageService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task SetUserData(string username, string email, string role)
    {
        await _js.InvokeVoidAsync("sessionStore.setUserData", username, email, role);
    }

    public async Task<string> GetUsername() => await _js.InvokeAsync<string>("sessionStore.getUsername");
    public async Task<string> GetEmail() => await _js.InvokeAsync<string>("sessionStore.getEmail");
    public async Task<string> GetRole() => await _js.InvokeAsync<string>("sessionStore.getRole");

    public async Task ClearUserData()
    {
        await _js.InvokeVoidAsync("sessionStore.clearUserData");
    }
}