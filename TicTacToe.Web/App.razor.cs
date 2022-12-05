using Avalonia.Web.Blazor;

namespace TicTacToe.Web;

public partial class App
{
    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        WebAppBuilder.Configure<TicTacToe.App>()
            .SetupWithSingleViewLifetime();
    }
}