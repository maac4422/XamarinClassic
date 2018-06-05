using Android.App;
using Android.Support.V4.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.Widget;
using Android.Views;
using UFCApp.Android.Fragments;
using SupportFragmentTransaction = Android.Support.V4.App.FragmentTransaction;
using Android.Support.Design.Widget;
using SupportFragment = Android.Support.V4.App.Fragment;

namespace UFCApp.Android
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Theme = "@style/MyTheme")]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        #region Attributes
        private SupportToolbar toolbar;
        private MyActionBarDrawerToggle myActionBarDrawerToggle;
        private DrawerLayout drawerLayout;
        private SupportFragmentTransaction fragmentTransaction;
        NavigationView navigationView;
        #endregion

        #region LyfeCycles
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            InitializeVariables();
            SetSupportActionBar(toolbar);
            SetMainFragment();

            myActionBarDrawerToggle = new MyActionBarDrawerToggle(
                this,
                drawerLayout,
                Resource.String.openDrawer,
                Resource.String.closeDrawer
            );

            drawerLayout.AddDrawerListener(myActionBarDrawerToggle);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            myActionBarDrawerToggle.SyncState();
            

            SetTitleActionBar(savedInstanceState);
        }
        #endregion

        #region Override Methods
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            return myActionBarDrawerToggle.OnOptionsItemSelected(item);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            if (drawerLayout.IsDrawerOpen((int)GravityFlags.Left))
            {
                outState.PutString("DrawerState", "Opened");
            }
            else
            {
                outState.PutString("DrawerState", "Closed");
            }
            base.OnSaveInstanceState(outState);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            myActionBarDrawerToggle.SyncState();
        }
        #endregion

        #region Interface Methods
        public bool OnNavigationItemSelected(IMenuItem menuItem)
        {
            int id = menuItem.ItemId;
            if (id.Equals(Resource.Id.nav_main))
            {
                NavigateToFragment(new NewsFragment(), "Noticias");
            }
            else if(id.Equals(Resource.Id.nav_about))
            {
                NavigateToFragment(new AboutFragment(), "Acerca de");
            }
            drawerLayout.CloseDrawers();
            return true;
        }
        #endregion

        #region PrivateMethods
        private void InitializeVariables()
        {
            toolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            if (navigationView != null)
            {
                navigationView.SetNavigationItemSelectedListener(this);
            }
        }

        private void SetMainFragment()
        {
            fragmentTransaction = SupportFragmentManager.BeginTransaction();
            fragmentTransaction.Add(Resource.Id.fragmentContainer, new AboutFragment(), "Noticias");
            fragmentTransaction.Commit();
        }

        private void SetTitleActionBar(Bundle bundle)
        {
            if (bundle != null)
            {
                if (bundle.GetString("DrawerState").Equals("Opened"))
                {
                    SupportActionBar.SetTitle(Resource.String.openDrawer);
                }
                else
                {
                    SupportActionBar.SetTitle(Resource.String.closeDrawer);
                }
            }
            else
            {
                //This is the first time the activity is run
                SupportActionBar.SetTitle(Resource.String.closeDrawer);
            }
        }

        private void NavigateToFragment(SupportFragment fragment, string tag )
        {
            fragmentTransaction = SupportFragmentManager.BeginTransaction();
            fragmentTransaction.Add(Resource.Id.fragmentContainer, fragment, tag);
            fragmentTransaction.Replace(Resource.Id.fragmentContainer, fragment, tag);
            fragmentTransaction.AddToBackStack(null);
            fragmentTransaction.Commit();
        }
       
        #endregion
    }
}

