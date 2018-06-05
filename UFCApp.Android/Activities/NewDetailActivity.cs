using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;

namespace UFCApp.Android.Activities
{
    [Activity(Label = "NewDetailActivity")]
    public class NewDetailActivity : Activity
    {
        #region Attributes
        private WebView webView;
        private int newId;
        #endregion

        #region LifeCycles
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //SetContentView(Resource.Layout.NewDetail);
            //webView = FindViewById<WebView>(Resource.Id.newWebView);
            int newId = Intent.GetIntExtra("newId", 1);
            //webView.Settings.JavaScriptEnabled = true;
            //webView.LoadUrl("http://www.google.com");
            //webView.SetWebViewClient(new NewsWebViewClient());
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

        public class NewsWebViewClient : WebViewClient
        {
            public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
            {
                view.LoadUrl(request.Url.ToString());
                return true;
            }
        }
    }
}