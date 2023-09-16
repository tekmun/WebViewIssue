using Foundation;
using WebKit;

namespace WebViewIssue
{
  public class WebViewUIDelegate : WKUIDelegate
  {
    public WebViewUIDelegate()
    {

    }
    [Export("webView:requestMediaCapturePermissionForOrigin:initiatedByFrame:type:decisionHandler:")]
    public override void RequestMediaCapturePermission(WKWebView webView, WKSecurityOrigin origin, WKFrameInfo frame, WKMediaCaptureType type, Action<WKPermissionDecision> decisionHandler)
    {
      decisionHandler(WKPermissionDecision.Grant);
    }
    public override void RequestDeviceOrientationAndMotionPermission(WKWebView webView, WKSecurityOrigin origin, WKFrameInfo frame, Action<WKPermissionDecision> decisionHandler)
    {
      base.RequestDeviceOrientationAndMotionPermission(webView, origin, frame, decisionHandler);
    }
  }
}
