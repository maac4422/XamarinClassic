using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using System;
using Android.Support.V4.App;
using UFCApp.Droid.Fragments;

namespace UFCApp.Droid
{
    [Activity(Label = "UFCApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : FragmentActivity
    {
        TabLayout tabLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            tabLayout = FindViewById<TabLayout>(Resource.Id.mainTabLayout);
            tabLayout.TabSelected += TabLayoutTabSelected;

            FragmentNavigate(new NewsFragment());
        }

        private void TabLayoutTabSelected(object sender, TabLayout.TabSelectedEventArgs e)
        {
            switch (e.Tab.Position)
            {
                case 0:
                    FragmentNavigate(new NewsFragment());
                    break;
                case 1:
                    FragmentNavigate(new EventsFragment());
                    break;
            }
        }

        private void FragmentNavigate(Android.Support.V4.App.Fragment fragment)
        {
            var transaction = SupportFragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.contentFrame, fragment);
            transaction.Commit();
        }
    }
}

