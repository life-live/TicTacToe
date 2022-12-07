using System.Runtime.Versioning;
using Avalonia;
using Avalonia.ReactiveUI;
using Avalonia.Web;
using TicTacToe;

[assembly: SupportedOSPlatform("browser")]

internal class Program
{
    private static void Main(string[] args)
    {
        BuildAvaloniaApp()
            .UseReactiveUI()
            .SetupBrowserApp("out");
    }

    public static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<App>();
    }
}