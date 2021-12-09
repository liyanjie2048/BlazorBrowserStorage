using Microsoft.JSInterop;

namespace Liyanjie.Blazor.BrowserStorage;

public class LocalStorage : BrowserStorage
{
    public LocalStorage(IJSRuntime jsRuntime, bool base64Encode) : base("localStorage", jsRuntime, base64Encode) { }
}
