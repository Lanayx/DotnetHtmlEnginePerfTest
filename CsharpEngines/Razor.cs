using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CsharpEngines;

public class Razor
{
    public static HtmlRenderer GetRenderer()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        var serviceProvider = services.BuildServiceProvider();
        var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
        return new HtmlRenderer(serviceProvider, loggerFactory);
    }
}

public class RazorDynamic
{
    public static HtmlRenderer renderer = Razor.GetRenderer();

    private static Dictionary<string, object?> paramDictionary = new Dictionary<string, object?>()
    {
        { "Num", 3 },
        { "Header", "Header"}
    };

    public static async Task<string> RenderToString()
    {
        return await renderer.Dispatcher.InvokeAsync(async () =>
        {
            var parameters = ParameterView.FromDictionary(paramDictionary);
            var output = await renderer.RenderComponentAsync<RazorView>(parameters);
            return output.ToHtmlString();
        });
    }
}