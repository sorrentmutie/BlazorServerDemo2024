using BlazorDemoComponentsLibrary.Interop;
using Microsoft.JSInterop;

namespace BlazorDemoComponents.Library.Interop;

public class MiaClasseDiInterop: IDisposable, IAsyncDisposable
{
    private readonly IJSRuntime jSRuntime;
    private DotNetObjectReference<HelloHelper>? objRef;
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;


    public MiaClasseDiInterop(IJSRuntime jSRuntime)
    {
        this.jSRuntime = jSRuntime;
        moduleTask = new(() => jSRuntime.InvokeAsync<IJSObjectReference>(
        "import", "./_content/BlazorDemoComponentsLibrary/myCode.js").AsTask());

    }

    public async ValueTask<int> EseguiMiaSomma(int a, int b)
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<int>("miaSomma", a, b);
    }

    public async ValueTask<int> EseguiMiaSommaQuadratica(int a, int b, int c)
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<int>("sommaQuadratica", a, b, c);
    }

    public async Task RestituisceArrayAsync()
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("restituisceArrayAsync");
    }

    public async ValueTask<string> ChiamaSayHello(string name)
    {
        var module = await moduleTask.Value;
        var helloHelper = new HelloHelper(name);
        objRef = DotNetObjectReference.Create(helloHelper);
        return await module.InvokeAsync<string>("sayHello", objRef);
    }

    public void Dispose()
    {
        objRef?.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}

