using Microsoft.JSInterop;

namespace Liyanjie.Blazor.BrowserStorage;

public class SessionStorage : BrowserStorage
{
    public SessionStorage(IJSRuntime jsRuntime, bool base64Encode) : base("sessionStorage", jsRuntime, base64Encode) { }
}
