using System;
using Android.Content;
using Android.Support.V4.App;
using Java.Lang;
using UFCApp.Android.Fragments;

namespace UFCApp.Android.Adapters
{
    public class OptionsGalleryAdapter : FragmentPagerAdapter
    {

        Context context;
        private string[] titles = new string[] { "Noticias", "Eventos" };

        public OptionsGalleryAdapter(FragmentManager fragmentManager) : base(fragmentManager)
        {
        }
        
        public override int Count => 2;

        public override Fragment GetItem(int position)
        {
            switch (position)
            {
                case 0:
                    return new NewsFragment();
                    break;
                case 1:
                    return new EventsFragment();
                    break;
            }
            return null;
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(titles[position]);
        }
    }
}