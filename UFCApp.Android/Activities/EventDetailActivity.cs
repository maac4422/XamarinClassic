using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;

namespace UFCApp.Android.Activities
{
    [Activity(Label = "EventDetailActivity")]
    public class EventDetailActivity : Activity
    {
        #region Attributes
        private WebView webView;
        private int eventId;
        #endregion

        #region LifeCycles
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.event_detail);
            //webView = FindViewById<WebView>(Resource.Id.eventWebView);
            int newId = Intent.GetIntExtra("eventId", 1);
            //webView.Settings.JavaScriptEnabled = true;
            //webView.LoadUrl("http://www.google.com");
            //webView.SetWebViewClient(new EventsWebViewClient());
        }
        #endregion

        #region Events
        public override bool OnKeyDown([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.Back && webView.CanGoBack())
            {
                webView.GoBack();
                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }
        #endregion

        #region Methods
        #endregion

        public class EventsWebViewClient : WebViewClient
        {
            public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
            {
                view.LoadUrl(request.Url.ToString());
                return true;
            }
        }
    }
}