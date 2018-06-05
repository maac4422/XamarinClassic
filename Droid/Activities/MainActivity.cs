namespace UFCApp.Droid
{
    using System;
    using Android.App;
    using Android.OS;
    using Android.Support.Design.Widget;
    using Android.Support.V7.App;
    using Android.Support.V7.Widget;
    using UFCApp.Droid.Fragments;
    using SupportToolbar = Android.Support.V7.Widget.Toolbar;

    [Activity(Label = "UFCApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {
        #region Attributes
        private TabLayout tabLayout;
        private SupportToolbar toolbar;
        #endregion

        #region LifeCycle
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            //toolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            //SetSupportActionBar(toolbar);
           
        }


        #endregion

        #region Methods
        

        
        #endregion
    
    }
}

