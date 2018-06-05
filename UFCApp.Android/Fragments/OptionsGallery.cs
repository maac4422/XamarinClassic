using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;

namespace UFCApp.Android.Fragments
{
    public class OptionsGallery : Fragment
    {
        #region Attributes
        private AppBarLayout appBar;
        private TabLayout tabs;
        private ViewPager viewPager;
        #endregion

        #region LyfeClycles
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return base.OnCreateView(inflater, container, savedInstanceState);
        }
        #endregion

        #region Private Methods
        #endregion
    }
}