namespace UFCApp.Droid.Fragments
{
    using Android.OS;
    using Android.Support.V7.Widget;
    using Android.Views;
    using BusinessLayer.BusinessLogic;
    using BusinessLayer.Interfaces;
    using Models.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UFCApp.Droid.Adapters;

    public class EventsFragment : Android.Support.V4.App.Fragment
    {
        #region Attributes
        private IEventsBusinessLogic eventsBusinessLogic;
        private RecyclerView recyclerView;
        private RecyclerView.Adapter adapter;
        private RecyclerView.LayoutManager layoutManager;
        private List<Events> events;
        #endregion

        #region LifeCycle
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            eventsBusinessLogic = new EventsBusinessLogic();
        }

        public override void OnResume()
        {
            base.OnResume();
            eventsBusinessLogic = new EventsBusinessLogic();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var rootView = inflater.Inflate(Resource.Layout.Events, container, false);
            recyclerView = rootView.FindViewById<RecyclerView>(Resource.Id.eventsRecyclerView);

            var taskGetEvents = Task.Run(async () => {
                events = await eventsBusinessLogic.GetEvents();
            });
            taskGetEvents.Wait();

            // A LinearLayoutManager is used here, this will layout the elements in a similar fashion
            // to the way ListView would layout elements. The RecyclerView.LayoutManager defines how the
            // elements are laid out.
            layoutManager = new LinearLayoutManager(Activity);
            recyclerView.SetLayoutManager(layoutManager);
            

            adapter = new EventsAdapter(this.Activity, events);
            // Set CustomAdapter as the adapter for RecycleView
            recyclerView.SetAdapter(adapter);
            return rootView;
        }
        #endregion
    }
}