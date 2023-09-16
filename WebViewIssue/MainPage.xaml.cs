using Microsoft.Maui.Controls;
using WebViewIssue;
#if IOS || MACCATALYST
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
#endif

namespace WebViewIssue;
public partial class MainPage : ContentPage
{
    private int currentheight = -1, currentwidth = -1;
    public MainPage()
    {
        InitializeComponent();
        jitsipageWV.Source = new Uri("https://webrtc.github.io/samples/src/content/getusermedia/gum/");
        SizeChanged += DeviceSizeChanged;
    }
    private void DeviceSizeChanged(object sender, EventArgs args)
    {
        currentheight = (int)Math.Floor(Height);
        currentwidth = (int)Math.Floor(Width);
        ChangedSize();
    }
    public void ChangedSize()
    {
    }
}