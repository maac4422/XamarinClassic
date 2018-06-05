using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using BusinessLayer.BusinessLogic;
using BusinessLayer.Interfaces;
using Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Support.V4.App;

namespace UFCApp.Android.Fragments 
{
    public class EventsFragment : Fragment
    {
        #region Attributes
        private IEventsBusinessLogic eventsBusinessLogic;
        private RecyclerView recyclerView;
        private RecyclerView.Adapter adapter;
        private RecyclerView.LayoutManager layoutManager;
        private List<Events> events;
        #endregion

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.Events, container, false);

            return view;
        }
    }
}