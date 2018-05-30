namespace UFCApp.Droid.Adapters
{
    using System.Collections.Generic;
    using Android.Support.V7.Widget;
    using Android.Views;
    using Android.Widget;
    using Models.Models;

    class NewsAdapter : RecyclerView.Adapter
    {
        #region Attributes
        List<News> news;
        #endregion

        #region Constructors
        public NewsAdapter(List<News> news)
        {
            this.news = news;
        }
        #endregion

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
        }
        
        
        public override int ItemCount => news.Count;
    }

    class NewsAdapterViewHolder : RecyclerView.ViewHolder
    {
        #region Propierties
        public TextView Title { get; private set; }
        #endregion

        public NewsAdapterViewHolder(View v) : base(v)
        {
            Title = (TextView)v.FindViewById(Resource.Id.newTitle);
        }
    }
}