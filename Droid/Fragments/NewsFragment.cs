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

    public class NewsFragment : Android.Support.V4.App.Fragment
    {
        #region Attributes
        private INewsBusinessLogic newsBusinessLogic;
        private RecyclerView recyclerView;
        private RecyclerView.Adapter adapter;
        private RecyclerView.LayoutManager layoutManager;
        private List<News> news;
        #endregion

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            newsBusinessLogic = new NewsBusinessLogic();
        }

        public override void OnResume()
        {
            base.OnResume();
            newsBusinessLogic = new NewsBusinessLogic();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var rootView = inflater.Inflate(Resource.Layout.News, container, false);
            recyclerView = rootView.FindViewById<RecyclerView>(Resource.Id.newRecyclerView);

            var taskGetEvents = Task.Run(async () => {
                news = await newsBusinessLogic.GetNews();
            });
            taskGetEvents.Wait();

            // A LinearLayoutManager is used here, this will layout the elements in a similar fashion
            // to the way ListView would layout elements. The RecyclerView.LayoutManager defines how the
            // elements are laid out.
            layoutManager = new LinearLayoutManager(Activity);
            recyclerView.SetLayoutManager(layoutManager);


            adapter = new NewsAdapter(news);
            // Set CustomAdapter as the adapter for RecycleView
            recyclerView.SetAdapter(adapter);
            return rootView;
        }


    }
}