namespace UFCApp.Droid.Adapters
{
    using System.Collections.Generic;
    using Android.App;
    using Android.Support.V7.Widget;
    using Android.Views;
    using Android.Widget;
    using Models.Models;
    using Square.Picasso;

    class NewsAdapter : RecyclerView.Adapter
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
            var id = Resource.Layout.NewCell;
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
            if(!string.IsNullOrEmpty(item.Image)) { 
                Picasso.With(activity).Load(item.Image).Into(viewHolder.Image);
            }
        }
        
        public override int ItemCount => news.Count;
        #endregion
    }

    class NewsAdapterViewHolder : RecyclerView.ViewHolder
    {
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
        }
        #endregion
    }
}