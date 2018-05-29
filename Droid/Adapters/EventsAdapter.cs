using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Models.Models;

namespace UFCApp.Droid.Adapters
{
    class EventsAdapter : BaseAdapter
    {

        Context context;
        List<Events> events;

        public EventsAdapter(Context context, List<Events> events)
        {
            this.context = context;
            this.events = events;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            EventsAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as EventsAdapterViewHolder;

            if (holder == null)
            {
                holder = new EventsAdapterViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                //replace with your item and your holder items
                //comment back in
                view = inflater.Inflate(Resource.Layout.EventCell, parent, false);
                //holder.Title = view.FindViewById<TextView>(Resource.Id.eventTitleTextView);
                view.Tag = holder;
            }


            //fill in your items
            var currentEvent = events[position];
            holder.Title.Text = currentEvent.Title;

            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return events.Count;
            }
        }

    }

    class EventsAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        public TextView Title { get; set; }
    }
}