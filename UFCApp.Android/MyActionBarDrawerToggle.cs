using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using SupportActionBarDrawerToggle = Android.Support.V7.App.ActionBarDrawerToggle;

namespace UFCApp.Android
{
    class MyActionBarDrawerToggle : SupportActionBarDrawerToggle
    {
        private AppCompatActivity hostActivity;
        private int openedResource;
        private int closedResource;

        public MyActionBarDrawerToggle(AppCompatActivity host, DrawerLayout drawerLayout, int openedResource, int closedResource) 
            : base(host, drawerLayout, openedResource, closedResource)
        {
            this.hostActivity = host;
            this.openedResource = openedResource;
            this.closedResource = closedResource;
        }

        public override void OnDrawerOpened(View drawerView)
        {
            base.OnDrawerOpened(drawerView);
            hostActivity.SupportActionBar.SetTitle(openedResource);
        }

        public override void OnDrawerClosed(View drawerView)
        {
            base.OnDrawerClosed(drawerView);
            hostActivity.SupportActionBar.SetTitle(closedResource);
        }

        public override void OnDrawerSlide(View drawerView, float slideOffset)
        {
            base.OnDrawerSlide(drawerView, slideOffset);
        }

    }
}