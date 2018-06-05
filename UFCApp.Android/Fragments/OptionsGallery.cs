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
using UFCApp.Android.Adapters;

namespace UFCApp.Android.Fragments
{
    public class OptionsGallery : Fragment
    {
        #region Attributes
        private TabLayout tabs;
        private ViewPager viewPager;
        private View view;
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
            view = inflater.Inflate(Resource.Layout.options_gallery, container, false);
            viewPager = view.FindViewById<ViewPager>(Resource.Id.viewpager);
            viewPager.Adapter = new OptionsGalleryAdapter(ChildFragmentManager);
            tabs = view.FindViewById<TabLayout>(Resource.Id.mainTabLayout);

            return view;
        }
        #endregion

      
    }
}