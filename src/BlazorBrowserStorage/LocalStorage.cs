using Microsoft.JSInterop;

namespace Liyanjie.Blazor.BrowserStorage;

public class LocalStorage : BrowserStorage
{
    public LocalStorage(IJSRuntime jsRuntime) : base("localStorage", jsRuntime) { }
}
