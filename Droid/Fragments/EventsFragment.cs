namespace UFCApp.Droid.Fragments
{
    using Android.OS;
    using BusinessLayer.BusinessLogic;
    using BusinessLayer.Interfaces;
    using UFCApp.Droid.Adapters;

    public class EventsFragment : Android.Support.V4.App.ListFragment
    {
        private IEventsBusinessLogic eventsBusinessLogic;
        public override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            eventsBusinessLogic = new EventsBusinessLogic();
            // Create your fragment here
            var events = await eventsBusinessLogic.GetEvents();
            ListAdapter = new EventsAdapter(Activity,events);
        }
    }
}