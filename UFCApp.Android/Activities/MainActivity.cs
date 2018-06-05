using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.Widget;
using Android.Views;
using UFCApp.Android.Fragments;

namespace UFCApp.Android
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Theme = "@style/MyTheme")]
    public class MainActivity : AppCompatActivity
    {
        #region Attributes
        private SupportToolbar toolbar;
        private MyActionBarDrawerToggle myActionBarDrawerToggle;
        private DrawerLayout drawerLayout;
        private ListView leftDrawer;
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
            myActionBarDrawerToggle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
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

        #region PrivateMethods
        private void InitializeVariables()
        {
            toolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
        }

        private void SetMainFragment()
        {
            var transaction = SupportFragmentManager.BeginTransaction();
            transaction.Add(Resource.Id.fragmentContainer, new NewsFragment(), "News");
            transaction.Commit();
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
        #endregion
    }
}

