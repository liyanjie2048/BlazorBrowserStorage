using Microsoft.JSInterop;

namespace Liyanjie.Blazor.BrowserStorage;

public class SessionStorage : BrowserStorage
{
    public SessionStorage(IJSRuntime jsRuntime) : base("sessionStorage", jsRuntime) { }
}
