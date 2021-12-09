using System.Text;
using System.Text.Json;

using Microsoft.JSInterop;

namespace Liyanjie.Blazor.BrowserStorage;

public abstract class BrowserStorage
{
    readonly string _storageName;
    readonly IJSRuntime _jsRuntime;
    readonly bool _base64Encode;

    protected BrowserStorage(
        string storeName,
        IJSRuntime jsRuntime,
        bool base64Encode)
    {
        if (string.IsNullOrEmpty(storeName))
            throw new ArgumentException("The value cannot be null or empty", nameof(storeName));

        _storageName = storeName;
        _jsRuntime = jsRuntime ?? throw new ArgumentNullException(nameof(jsRuntime));
        _base64Encode = base64Encode;
    }

    public ValueTask SetAsync<TValue>(string key, TValue? value)
    {
        if (string.IsNullOrEmpty(key))
            throw new ArgumentException("Cannot be null or empty", nameof(key));

        var json = JsonSerializer.Serialize(value);
        if (_base64Encode)
            json = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
        return _jsRuntime.InvokeVoidAsync($"{_storageName}.setItem", key, json);
    }

    public async ValueTask<TValue?> GetAsync<TValue>(string key)
    {
        var json = await _jsRuntime.InvokeAsync<string>($"{_storageName}.getItem", key);
        if (string.IsNullOrEmpty(json))
            return default;

        try
        {
            if (_base64Encode)
                json = Encoding.UTF8.GetString(Convert.FromBase64String(json));
            return JsonSerializer.Deserialize<TValue>(json);
        }
        catch
        {
            return default;
        }
    }

    public ValueTask DeleteAsync(string key)
        => _jsRuntime.InvokeVoidAsync($"{_storageName}.removeItem", key);
}
