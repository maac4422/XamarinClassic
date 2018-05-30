namespace UFCApp.Droid.Adapters
{
    using System.Collections.Generic;
    using Android.Support.V7.Widget;
    using Android.Views;
    using Android.Widget;
    using Models.Models;

    public class EventsAdapter : RecyclerView.Adapter
    {
        #region Attributes
        List<Events> events;
        #endregion

        #region Constructors
        public EventsAdapter(List<Events> events)
        {
            this.events = events;
        }
        #endregion

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            //Setup and inflate your layout here
            var id = Resource.Layout.EventCell;
            View view = LayoutInflater.From(parent.Context)
                .Inflate(id, parent, false);
            EventsAdapterViewHolder viewHolder = new EventsAdapterViewHolder(view);
            return viewHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var item = events[position];
            var viewHolder = holder as EventsAdapterViewHolder;
            viewHolder.Title.Text = item.Title;
        }
        
        public override int ItemCount => events.Count;
    }

    public class EventsAdapterViewHolder : RecyclerView.ViewHolder
    {

        #region Propierties
        public TextView Title{ get; private set; }
        #endregion

        public EventsAdapterViewHolder(View v) : base(v)
        {
            Title = (TextView)v.FindViewById(Resource.Id.eventTitleTextView);
        }
    }
}