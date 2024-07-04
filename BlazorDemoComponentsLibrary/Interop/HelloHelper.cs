using Microsoft.JSInterop;

namespace BlazorDemoComponentsLibrary.Interop;

public class HelloHelper
{
    public HelloHelper(string name)
    {
        Name = name;
    }

    public string Name { get; init; }

    [JSInvokable]
    public string SayHello()
    {
        return $"Hello, {Name}!";
    }
}
