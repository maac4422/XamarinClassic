using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Models.Models;
using Square.Picasso;
using UFCApp.Android.Activities;

namespace UFCApp.Android.Adapters
{
    class NewsAdapter : RecyclerView.Adapter, IItemClickListener
    {
        #region Attributes
        private List<News> news;
        private Activity activity;
        #endregion

        #region Constructors
        public NewsAdapter(Activity activity, List<News> news)
        {
            this.activity = activity;
            this.news = news;
        }
        #endregion

        #region Methods
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            //Setup and inflate your layout here
            var id = Resource.Layout.new_cell;
            View view = LayoutInflater.From(parent.Context)
                .Inflate(id, parent, false);
            NewsAdapterViewHolder viewHolder = new NewsAdapterViewHolder(view);
            return viewHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var item = news[position];
            var viewHolder = holder as NewsAdapterViewHolder;
            viewHolder.Title.Text = item.Title;
            viewHolder.Author.Text = item.Author;
            if (!string.IsNullOrEmpty(item.Image))
            {
                Picasso.With(activity).Load(item.Image).Into(viewHolder.Image);
            }
            viewHolder.SetItemClickListener(this);
        }

        public override int ItemCount => news.Count;

        public void OnClick(View itemView, int position, bool isLongClick)
        {
            var intent = new Intent(activity, typeof(NewDetailActivity));
            intent.PutExtra("newId", position);
            activity.StartActivity(intent);
        }

        #endregion
    }

    class NewsAdapterViewHolder : RecyclerView.ViewHolder, View.IOnClickListener, View.IOnLongClickListener
    {
        #region Attributes
        private IItemClickListener itemClickListener;
        #endregion

        #region Propierties
        public TextView Title { get; private set; }
        public TextView Author { get; private set; }
        public ImageView Image { get; private set; }
        #endregion

        #region Constructors
        public NewsAdapterViewHolder(View v) : base(v)
        {
            Title = (TextView)v.FindViewById(Resource.Id.newTitleTextView);
            Author = (TextView)v.FindViewById(Resource.Id.newAuthorTextView);
            Image = (ImageView)v.FindViewById(Resource.Id.newImageView);

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