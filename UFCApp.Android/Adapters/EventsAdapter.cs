using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Models.Models;
using Square.Picasso;

namespace UFCApp.Android.Adapters
{
    public class EventsAdapter : RecyclerView.Adapter, IItemClickListener
    {
        #region Attributes
        List<Events> events;
        private Activity activity;
        #endregion

        #region Constructors
        public EventsAdapter(Activity activity, List<Events> events)
        {
            this.activity = activity;
            this.events = events;
        }
        #endregion

        #region Methods
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            //Setup and inflate your layout here
            var id = Resource.Layout.event_cell;
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
            viewHolder.BaseTitle.Text = item.BaseTitle;
            viewHolder.EventDate.Text = item.EventDate.ToString("dd,mm,yyyy");
            if (!string.IsNullOrEmpty(item.Image))
            {
                Picasso.With(activity).Load(item.Image).Into(viewHolder.Image);
            }
            viewHolder.SetItemClickListener(this);
        }

        public override int ItemCount => events.Count;

        public void OnClick(View itemView, int position, bool isLongClick)
        {
            //var intent = new Intent(activity, typeof(EventDetailActivity));
            //intent.PutExtra("newId", position);
            //activity.StartActivity(intent);
        }
        #endregion
    }

    public class EventsAdapterViewHolder : RecyclerView.ViewHolder, View.IOnClickListener, View.IOnLongClickListener
    {
        #region Attributes
        private IItemClickListener itemClickListener;
        #endregion  

        #region Propierties
        public TextView Title { get; private set; }
        public TextView BaseTitle { get; set; }
        public TextView EventDate { get; set; }
        public ImageView Image { get; set; }
        #endregion

        #region Constructors
        public EventsAdapterViewHolder(View v) : base(v)
        {
            Title = (TextView)v.FindViewById(Resource.Id.eventTitleTextView);
            BaseTitle = (TextView)v.FindViewById(Resource.Id.eventBaseTitleTextView);
            EventDate = (TextView)v.FindViewById(Resource.Id.eventDateTextView);
            Image = (ImageView)v.FindViewById(Resource.Id.eventImageView);

            v.SetOnClickListener(this);
            v.SetOnLongClickListener(this);
        }
        #endregion

        #region Methods
        public void SetItemClickListener(IItemClickListener itemClickListener)
        {
            this.itemClickListener = itemClickListener;
        }

        public void OnClick(View v)
        {
            itemClickListener.OnClick(v, AdapterPosition, false);
        }

        public bool OnLongClick(View v)
        {
            itemClickListener.OnClick(v, AdapterPosition, true);
            return true;
        }
        #endregion
    }
}