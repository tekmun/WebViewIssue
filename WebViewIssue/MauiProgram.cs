using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.PlatformConfiguration;
#if IOS || MACCATALYST
using UIKit;
using WebKit;
using CoreGraphics;
using Microsoft.Maui.Platform;
#endif

namespace WebViewIssue;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif
#if IOS || MACCATALYST
        Microsoft.Maui.Handlers.WebViewHandler.Mapper.Add("PermissionRequest", (handler, view) =>
            {
                if (UIDevice.CurrentDevice.CheckSystemVersion(15, 0))
                {
                  MainThread.BeginInvokeOnMainThread(() =>
                  {
                    handler.PlatformView.UIDelegate = new WebViewUIDelegate();
                  });
                }
            });
        return builder.Build();
#endif
	}
}

